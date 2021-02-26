using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

public class SaveLoadCode : MonoBehaviour
{
    Canvas mainCanvas;
    SaveLoadMenu saveLoadMenu;
    string uiResourcesPath;

    public string SavedCodesPath
    {
        get
        {
            return Application.persistentDataPath + "/SavedCodes/";
        }
    }

    // variables for read
    public BETargetObject beTargetObject;
    StreamWriter writer;
    List<string> virtualCode;

    // variables for load
    StreamReader reader;
    public string blocksPrefabsPath;
    Transform parent;

    private void Awake()
    {
        mainCanvas = GameObject.FindGameObjectWithTag("GameController").transform.GetChild(1).GetComponent<Canvas>();
    }

    private void Start()
    {
        foreach (Transform child in transform.parent)
        {
            if (child.GetComponent<SaveLoadMenu>())
            {
                saveLoadMenu = child.GetComponent<SaveLoadMenu>();
            }
        }

        uiResourcesPath = "prefabs/UI/";

        blocksPrefabsPath = "prefabs/Blocks/";
        parent = transform;
        virtualCode = new List<string>();
    }

    public enum DialogOptions { save, load }
    public DialogOptions dialogOption;

    public void SetupSaveOrLoadDialog(DialogOptions option)
    {
        if (option == DialogOptions.save)
        {
            saveLoadMenu.transform.GetChild(0).GetComponent<Text>().text = "Save Panel";
            saveLoadMenu.transform.GetChild(2).GetComponent<InputField>().interactable = true;
            saveLoadMenu.transform.GetChild(3).gameObject.SetActive(true);
            saveLoadMenu.transform.GetChild(4).gameObject.SetActive(false);
            saveLoadMenu.transform.GetChild(5).gameObject.SetActive(true);
            saveLoadMenu.transform.GetChild(6).gameObject.SetActive(true);
            saveLoadMenu.transform.GetChild(7).gameObject.SetActive(false);
            saveLoadMenu.transform.GetChild(8).gameObject.SetActive(false);
        }
        else if (option == DialogOptions.load)
        {
            saveLoadMenu.transform.GetChild(0).GetComponent<Text>().text = "Load Panel";
            saveLoadMenu.transform.GetChild(2).GetComponent<InputField>().interactable = false;
            saveLoadMenu.transform.GetChild(2).GetComponent<InputField>().text = "";
            saveLoadMenu.transform.GetChild(3).gameObject.SetActive(false);
            saveLoadMenu.transform.GetChild(4).gameObject.SetActive(true);
            saveLoadMenu.transform.GetChild(5).gameObject.SetActive(true);
            saveLoadMenu.transform.GetChild(6).gameObject.SetActive(true);
            saveLoadMenu.transform.GetChild(7).gameObject.SetActive(false);
            saveLoadMenu.transform.GetChild(8).gameObject.SetActive(false);
        }
        dialogOption = option;

        Transform filesContent = saveLoadMenu.transform.GetChild(1).GetChild(0).GetChild(0);
        foreach (Transform child in filesContent)
        {
            Destroy(child.gameObject);
        }

        saveLoadMenu.gameObject.SetActive(true);


        try
        {

            for (int i = 0; i < Controller.codeName.Count; i++)
            {
                if (Controller.codeName.Count > 0)
                {
                    string name = Controller.codeName[i];
                    GameObject toggleInstance = Instantiate(Resources.Load(uiResourcesPath + "Toggle", typeof(GameObject))) as GameObject;

                    toggleInstance.transform.localScale = Vector3.one * mainCanvas.scaleFactor;

                    toggleInstance.GetComponentInChildren<Text>().text = name;
                    toggleInstance.transform.SetParent(filesContent);
                    toggleInstance.GetComponent<Toggle>().group = toggleInstance.transform.parent.GetComponent<ToggleGroup>();
                    toggleInstance.transform.SetAsLastSibling();

                    toggleInstance.GetComponent<Toggle>().onValueChanged.AddListener(delegate
                    {
                        saveLoadMenu.GetComponent<SaveLoadMenu>().GetSelectedBECodeName(toggleInstance.GetComponentInChildren<Text>().text);
                    });

                }
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }



    //-- write code file --
    public void OpenSaveDialog()
    {
        SetupSaveOrLoadDialog(DialogOptions.save);
    }

    public void BESaveCode(string path)
    {
        WriteVirtualCodeToFile(path, beTargetObject);
    }

    public void WriteVirtualCodeToFile(string path, BETargetObject beTargetObject)
    {
        virtualCode = new List<string>();
        if (path.Length != 0)
        {
            virtualCode.Clear();

            foreach (BEBlock blockGroup in beTargetObject.beBlockGroupsList)
            {
                BEBlock block = blockGroup.GetComponent<BEBlock>();

                virtualCode.AddRange(TranslateBlockGroupToVirtualCode(block));
            }


            string CodeString = "";
            for (int i = 0; i < virtualCode.Count; i++)
            {
                if (i == virtualCode.Count - 1)
                    CodeString = CodeString + virtualCode[i];
                else
                    CodeString = CodeString + virtualCode[i] + "#";
            }
            /*foreach (string line in virtualCode)
            {
                
                CodeString = CodeString + line + "#";

            }*/
            StartCoroutine(UpdateUserDetails(saveLoadMenu.TextInput, CodeString));

            writer = new StreamWriter(path, false);
            foreach (string line in virtualCode)
            {
                writer.WriteLine(line);
            }
            writer.Close();
        }
    }

    IEnumerator UpdateUserDetails(string codeName, string code)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", Controller.token);
        form.AddField("securityid", "l3k5lrAHZ2UVcJtSdi57UC3zNhItf9");
        form.AddField("settings", codeName + "#" + code);
        //form.AddField("settings", "sounds:"+"on");
        //form.AddBinaryData("settings", File.ReadAllBytes(Application.persistentDataPath + "/SavedCodes/"), Path.GetFileName(Application.persistentDataPath + "/SavedCodes/somefile.BE"));

        using (UnityWebRequest www = UnityWebRequest.Post("https://parcrobotics.org/index.php?option=com_games&task=games.updateusersetting", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, string> dict in www.GetResponseHeaders())
                {
                    sb.Append(dict.Key).Append(": \t[").Append(dict.Value).Append("]\n");
                }

                //Print Headers
                //Debug.Log(sb.ToString());

                //Print Body
                //Debug.Log(www.downloadHandler.text);

                Debug.Log(code);
                Controller.codeName.Clear();
                Controller.serverCode.Clear();
                StartCoroutine(Controller.UserDetails());
            }
        }
    }


    public List<string> TranslateBlockGroupToVirtualCode(BEBlock block)
    {
        string hierarchyMarker = "";

        List<string> tempVirtualCode = new List<string>();
        TranslateSingleBlockToVirtualCode(block, tempVirtualCode, hierarchyMarker);

        GetChildBlocks(block, tempVirtualCode, hierarchyMarker);

        tempVirtualCode.Add(""); // write empty line after each group

        return tempVirtualCode;
    }

    public void TranslateSingleBlockToVirtualCode(BEBlock block, List<string> tempVirtualCode, string hierarchyMarker)
    {
        string inputs = "";
        inputs = WriteBlockInputs(block);

        string blockPosition = "";
        if (hierarchyMarker == "")
        {
            float x = block.transform.position.x;
            float y = block.transform.position.y;
            blockPosition = ":" + x.ToString(CultureInfo.InvariantCulture) + "," + y.ToString(CultureInfo.InvariantCulture);
        }

        tempVirtualCode.Add(hierarchyMarker + block.name + inputs + blockPosition);
    }

    public void GetChildBlocks(BEBlock parentBlock, List<string> tempVirtualCode, string hierarchyMarker)
    {
        hierarchyMarker += "\t";

        foreach (BEBlock block in parentBlock.beChildBlocksList)
        {
            TranslateSingleBlockToVirtualCode(block, tempVirtualCode, hierarchyMarker);

            if (block.beChildBlocksList.Count > 0)
            {
                GetChildBlocks(block, tempVirtualCode, hierarchyMarker);
            }
        }

        hierarchyMarker = hierarchyMarker.Substring(0, hierarchyMarker.Length - 1);
    }

    public string WriteBlockInputs(BEBlock block)
    {
        string inputs = "(";
        if (block.userInputIndexes.Count > 0)
        {
            block.InitializeInputs();
            for (int i = 0; i < block.userInputIndexes.Count; i++)
            {
                if (block.BlockHeader.GetChild(block.userInputIndexes[i]).GetComponent<BEBlock>())
                {
                    BEBlock operation = block.BlockHeader.GetChild(block.userInputIndexes[i]).GetComponent<BEBlock>();
                    inputs += operation.name;
                    inputs += WriteBlockInputs(operation);
                    inputs += ",";
                }
                else
                {
                    inputs += "'" + block.BeInputs.stringValues[i] + ",";
                }
            }
            if (inputs.Length > 0)
            {
                inputs = inputs.Substring(0, inputs.Length - 1);
            }
        }
        inputs += ")";
        return inputs;
    }

    //-- read code file --
    public void OpenLoadDialog()
    {
        SetupSaveOrLoadDialog(DialogOptions.load);
    }

    public void BELoadCode(string path)
    {
        virtualCode = new List<string>();
        parent = transform;

        virtualCode.Clear();
        Debug.Log("IsItWorking");
        //virtualCode = ReadFileToVirtualCode(path);
        virtualCode = Controller.serverCode;

        StartCoroutine(TranslateVirtualCodeToBlocks(virtualCode, parent, Vector2.zero));
    }

    public string ParseBlockName(string line)
    {
        string blockName = "";
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '(')
            {
                blockName = line.Remove(i);
                break;
            }
        }

        return blockName;
    }

    public string[] ParseBlockInputs(string line)
    {
        string blockInputs = "";
        int start = 0;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '(')
            {
                start = i;
                break;
            }
        }
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (line[i] == ')')
            {
                blockInputs = line.Substring(start + 1, i - start - 1);
                break;
            }
        }

        string[] inputArray = new string[0];
        start = 0;
        int jumpcount = 0;
        string value;
        for (int i = 0; i < blockInputs.Length; i++)
        {
            if (blockInputs[i] == '(')
            {
                jumpcount++;
            }
            if (blockInputs[i] == ')' && jumpcount > 0)
            {
                jumpcount--;
            }
            if (blockInputs[i] == ',' && jumpcount == 0)
            {
                value = blockInputs.Substring(start, i - start);

                Array.Resize(ref inputArray, inputArray.Length + 1);
                inputArray[inputArray.GetUpperBound(0)] = value;
                start = i + 1;
            }
        }
        value = blockInputs.Substring(start, blockInputs.Length - start);

        Array.Resize(ref inputArray, inputArray.Length + 1);
        inputArray[inputArray.GetUpperBound(0)] = value;

        return inputArray;
    }

    public string ParseBlockPosition(string line)
    {
        string blockPosition = "";

        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (line[i] == ':')
            {
                blockPosition = line.Substring(i + 1, line.Length - i - 1);
                break;
            }
        }

        return blockPosition;
    }

    public List<string> ReadFileToVirtualCode(string path)
    {
        if (path.Length != 0)
        {
            List<string> tempVirtualCode = new List<string>();
            reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                tempVirtualCode.Add(reader.ReadLine());
            }
            reader.Close();

            return tempVirtualCode;
        }
        else
        {
            return null;
        }
    }

    public IEnumerator TranslateVirtualCodeToBlocks(List<string> tempVirtualCode, Transform programmingEnv, Vector2 positionOffset)
    {
        GameObject blockInstance = programmingEnv.gameObject;
        Transform parent_ = programmingEnv;
        int hierarchyCounter;
        int previousHierarchyCounter = 0;

        if (tempVirtualCode != null)
        {
            foreach (string line in tempVirtualCode)
            {
                string codeLine = line;
                hierarchyCounter = codeLine.Split('\t').Length - 1;

                codeLine = codeLine.Replace("\t", "");

                if (codeLine.Length > 0)
                {
                    if (hierarchyCounter > previousHierarchyCounter)
                    {
                        parent_ = blockInstance.transform;
                    }
                    else if (hierarchyCounter < previousHierarchyCounter)
                    {
                        parent_ = parent_.parent;
                    }
                    if (hierarchyCounter == 0)
                    {
                        parent_ = programmingEnv;
                    }

                    string blockName = ParseBlockName(codeLine);
                    string[] inputsArray = ParseBlockInputs(codeLine);

                    GameObject blockFromResources = null;
                    try
                    {
                        blockFromResources = Resources.Load(blocksPrefabsPath + blockName, typeof(GameObject)) as GameObject;
                    }
                    catch
                    {
                        Debug.Log("Block not found in the resources/Blocks folder");
                    }

                    if (blockFromResources != null)
                    {
                        blockInstance = Instantiate(blockFromResources);

                        blockInstance.transform.localScale = Vector3.one * mainCanvas.scaleFactor;

                        BEBlock block = blockInstance.GetComponent<BEBlock>();
                        BEEventSystem.SetSelectedBlock(block, BEEventSystem.EventType.simulated);

                        blockInstance.name = blockName;

                        int siblingIndex = parent_.childCount;

                        if (hierarchyCounter == 0)
                        {
                            string[] positions = ParseBlockPosition(codeLine).Split(',');
                            float posX = float.Parse(positions[0], CultureInfo.InvariantCulture);
                            float posY = float.Parse(positions[1], CultureInfo.InvariantCulture);
                            blockInstance.transform.position = new Vector2(posX, posY) + positionOffset;
                        }

                        parent_.GetComponent<UIDrop>().SetBlockAtIndex(block, siblingIndex);

                        previousHierarchyCounter = hierarchyCounter;

                        LoadInputs(block, inputsArray);
                    }
                }

                //wait end of the frame to avoid sizing glitch
                yield return new WaitForEndOfFrame();
            }
        }

        BEEventSystem.SetSelectedBlock(null);

    }

    public void LoadInputs(BEBlock block, string[] inputsArray)
    {
        block.InitializeBlock();

        for (int index = 0; index < block.userInputIndexes.Count; index++)
        {
            if (inputsArray[index][0] == '\'')
            {

                string inputValue = inputsArray[index].Replace("'", "");

                block.SetDynamicUserInput(index, inputValue, false);

            }
            else
            {
                string blockName = ParseBlockName(inputsArray[index]);
                string[] blockInputs_ = ParseBlockInputs(inputsArray[index]);

                BEBlock block_ = block.SetDynamicUserInput(index, blockName, true);

                LoadInputs(block_, blockInputs_);
            }
        }
    }

    //-- delete file --
    public void BEDeleteCode(string fullPath)
    {
        File.Delete(fullPath);
        SetupSaveOrLoadDialog(dialogOption);
    }

    // v1.3 -Clear button added to delete all blocks from the BEProgrammingEnv
    //-- clear programming environment --
    public void BEClearCode()
    {
        for (int i = beTargetObject.beBlockGroupsList.Count - 1; i >= 0; i--)
        {
            UIDrag uiDrag = beTargetObject.beBlockGroupsList[i].GetComponent<UIDrag>();
            uiDrag.DragBlock();
        }
    }

}
