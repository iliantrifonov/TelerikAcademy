<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="UploadZipToDb.Upload" %>

<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ajax:ToolkitScriptManager runat="Server" />
            <h1>Upload your ZIP file here:</h1>

          <ajax:AsyncFileUpload runat="server" ID="FUpload"
              UploaderStyle="Modern"
              OnUploadedFileError="Upload_UploadedFileError"
              OnUploadedComplete="Upload_UploadedComplete" />
        </div>
    </form>
</body>
</html>
