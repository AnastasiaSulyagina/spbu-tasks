 //Anastasia Sulyagina (c) 2014
// ChatWithBot

open System
open System.Windows.Forms
open AIMLbot

let myBot = new Bot()
myBot.loadSettings()
let myUser = new AIMLbot.User("senderUser", myBot);
myBot.loadAIMLFromFiles();

let chatForm = new Form(Text = "ChatWithBot 1.0", Height = 350, Width = 600)
let sendMessageButton = new Button(Text = "Enter", Top = 250, Left = 455 )
let messageBox = new TextBox(Text = "Type your text", Top = 250, Left = 50, Width = 400)
let answerSpace = new Label(Top = 150, Left = 50, Height = 100, Width = 400)
let messageSpace = new Label(Top = 50, Left = 50, Height = 100, Width = 400)

chatForm.Controls.AddRange [| answerSpace; messageSpace; messageBox; sendMessageButton|]
chatForm.Show()

sendMessageButton.Click.Add (fun _ -> let s = messageBox.Text
                                      let r = new Request(s, myUser, myBot)
                                      let res = myBot.Chat(r)
                                      messageSpace.Text <- s
                                      answerSpace.Text <- res.Output.ToString()
                                      messageBox.Text <- ""
                                      )
Application.Run()