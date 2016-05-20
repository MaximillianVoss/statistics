<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectDate.aspx.cs" Inherits="Statistics.Pages.SelectDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../Styles/FormStyles.css" rel="stylesheet" />
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen"
        href="http://tarruda.github.com/bootstrap-datetimepicker/assets/css/bootstrap-datetimepicker.min.css" />
</head>
<script type="text/javascript"
    src="http://cdnjs.cloudflare.com/ajax/libs/jquery/1.8.3/jquery.min.js">
</script>
<script type="text/javascript"
    src="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/js/bootstrap.min.js">
</script>
<script type="text/javascript"
    src="http://tarruda.github.com/bootstrap-datetimepicker/assets/js/bootstrap-datetimepicker.min.js">
</script>
<script type="text/javascript"
    src="http://tarruda.github.com/bootstrap-datetimepicker/assets/js/bootstrap-datetimepicker.pt-BR.js">
</script>
<script type="text/javascript">
    $(function () {
        $('#datetimepickerStart').datetimepicker({
            format: 'yyyy-MM-dd',
            //format: 'yyyy-mm-dd',
            //pickDate: false
            pickTime: false
        });
    });
    $(function () {
        $('#datetimepickerSlut').datetimepicker({
            format: 'yyyy-MM-dd',
            //format: 'yyyy-mm-dd',
            //pickDate: false
            pickTime: false
        });
    });
</script>
<body>
    <form id="mainForm" runat="server">
        <div class="container well">
            <label class="label">rapportadStart</label>
            <div id="datetimepickerStart" class="input-append col-md-6">
                <%--data-format="hh:mm:ss"  type="text"--%>
                <asp:TextBox ID="rapportadStartTextBox" data-format="yyyy-mm-dd"  type="text" runat="server" />
                <span class="add-on">
                    <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                </span>
            </div>
            <label class="label">rapportadSlut</label>
            <div id="datetimepickerSlut" class="input-append col-md-6">
                <asp:TextBox ID="rapportadSlutTextBox" data-format="yyyy-mm-dd"  type="text"  runat="server" />
                <span class="add-on">
                    <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                </span>
            </div>
            <asp:Button ID="showTableBtn" CssClass="btn btn-primary" runat="server" Text="Visa" OnClick="showTableBtn_Click" />
        </div>
    </form>
</body>
</html>
