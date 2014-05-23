 //Anastasia Sulyagina (c) 2014
// ChatWithBot

open System
open System.Windows.Forms
open System.Drawing
open AIMLbot

let myBot = new Bot()
myBot.loadSettings()
let myUser = new AIMLbot.User("senderUser", myBot);
myBot.loadAIMLFromFiles();

let chatForm = new Form(Text = "Chat With Alice 1.0", Height = 700, Width = 600)
chatForm.Icon <- new Icon("small_icon.ico")
let messageBox = new TextBox(Text = "Type your text", Dock = DockStyle.Bottom, Left = 50, Width = 400)
let messageSpace = new RichTextBox(Dock = DockStyle.Fill, ReadOnly = true)
messageSpace.Multiline <- true

chatForm.Controls.AddRange [| messageSpace; messageBox|]
chatForm.Show()

messageBox.KeyDown.Add (fun f -> if f.KeyCode = Keys.Enter then
                                    let s = messageBox.Text
                                    let r = new Request(s, myUser, myBot)
                                    let res = myBot.Chat(r)
                                    messageSpace.AppendText("\nYou: " + s + "\nAlice: " + res.Output.ToString())
                                    messageSpace.ScrollToCaret()
                                    messageBox.Text <- ""
                                 )

Application.Run()