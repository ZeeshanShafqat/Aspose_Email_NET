﻿' ///////////////////////////////////////////////////////////////////////
' Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Email. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
' ///////////////////////////////////////////////////////////////////////

Imports System.IO
Imports Aspose.Email.Mail
Imports Aspose.Email.Outlook
Imports Aspose.Email.Pop3
Imports Aspose.Email
Imports Aspose.Email.Mime
Imports Aspose.Email.Imap
Imports System.Configuration
Imports System.Data
Imports Aspose.Email.Mail.Bounce
Imports Aspose.Email.Exchange

Public Class DeleteExchangeTask
    Public Shared Sub Run()
        ' Create instance of ExchangeClient class by giving credentials
        Dim client As IEWSClient = EWSClient.GetEWSClient("https://outlook.office365.com/ews/exchange.asmx", "testUser", "pwd", "domain")

        ' Get all tasks info collection from exchange
        Dim tasks As ExchangeMessageInfoCollection = client.ListMessages(client.MailboxInfo.TasksUri)

        ' Parse all the tasks info in the list
        For Each info As ExchangeMessageInfo In tasks
            ' Fetch task from exchange using current task info
            Dim task As ExchangeTask = client.FetchTask(info.UniqueUri)

            ' Check if the current task fulfills the search criteria
            If task.Subject.Equals("test") Then
                'Delete task from exchange
                client.DeleteTask(task.UniqueUri, DeleteTaskOptions.DeletePermanently)
            End If
        Next

        Console.WriteLine(Environment.NewLine + "Task deleted on Exchange Server successfully.")
    End Sub
End Class
