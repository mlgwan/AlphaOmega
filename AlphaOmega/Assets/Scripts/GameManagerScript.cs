using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
    public string username;

    public Text topText;
    private GameObject backButton;
    private Image playerTeamImage;
    private Sprite imageSprite;
    public Sprite backIcon;
    private GameObject menuButton;
    public GameObject chatInputField, chatScrollView, teamChatInputField, teamChatScrollView;

    public int maxMessages;
    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public Color info, playerMessage;
    public Image characterImage;

    [SerializeField]
    private List<Message> messageList;
    public string characterName;
    public GameObject[] buttons;
    private bool isOpen;
	// Use this for initialization
	void Start () {
        isOpen = false;
        messageList = new List<Message>();
        maxMessages = 20;

        backButton = GameObject.FindGameObjectWithTag("TeamDisplay/Back");
        menuButton = GameObject.FindGameObjectWithTag("MenuButton");
        buttons = GameObject.FindGameObjectsWithTag("Button");
        topText = GameObject.FindGameObjectWithTag("TopText").GetComponent<Text>();
        playerTeamImage = GameObject.FindGameObjectWithTag("TeamImage").GetComponent<Image>();
        imageSprite = playerTeamImage.sprite;



        backButton.GetComponent<Button>().interactable = false;


	}

    // Update is called once per frame
    public void openMenu() {

        if (isOpen)
        {
            foreach (GameObject button in buttons)
            {
                button.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            }
            characterImage.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }
       
        else {
            foreach (GameObject button in buttons) {
                button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
            characterImage.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
       
        isOpen = !isOpen;
    }



    public void goBack() {
        foreach (GameObject button in buttons)
        {
            button.GetComponent<RectTransform>().localScale = new Vector3(1,1, 1);
        }

        topText.text = characterName;
        playerTeamImage.sprite = imageSprite;
        menuButton.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        backButton.GetComponent<Button>().interactable = false;
        chatInputField.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 01);
        chatScrollView.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        teamChatInputField.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        teamChatScrollView.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    public void openChat() {
        foreach (GameObject button in buttons) {
            button.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        topText.text = "Chat";
        playerTeamImage.sprite = backIcon;
        menuButton.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        chatInputField.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        chatScrollView.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        backButton.GetComponent<Button>().interactable = true;
    }

    public void openTeamChat() {
        foreach (GameObject button in buttons)
        {
            button.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        topText.text = "Team-Chat";
        playerTeamImage.sprite = backIcon;
        menuButton.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        teamChatInputField.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        teamChatScrollView.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        backButton.GetComponent<Button>().interactable = true;

    }

    public void SendMessageToChat(string text, Message.MessageType messageType) {

        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
        Message newMessage = new Message();

        newMessage.messageText = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.messageText;
        newMessage.textObject.color = MessageTypeColor(messageType);
        messageList.Add(newMessage);
    }

    public void Update()
    {

        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(username + ": " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
 

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToChat("You pressed Space", Message.MessageType.info);
            }
        }


    }

    Color MessageTypeColor(Message.MessageType messageType) {
        Color color = info;

        switch (messageType) {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
        }

        return color;
    }

    public void AssignCharacteInfo() {
        characterImage.sprite = GameObject.Find("Player1").GetComponent<PlayerScript>().roleSprite;
        characterName = GameObject.Find("Player1").GetComponent<PlayerScript>().roleName;
        topText.text = characterName;
    }
}


[System.Serializable]
public class Message
{
    public string messageText;
    public Text textObject;
    public MessageType messageType;

    public enum MessageType {
        playerMessage,
        info
    }

}
