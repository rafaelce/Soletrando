<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="Soletrando.Index" %>

<!DOCTYPE html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <script src="js/jquery-1.12.1.js"></script>
    <script src="js/responsivevoice.js"></script>
    <title>Soletrando</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="css/narrow-jumbotron.css" rel="stylesheet">
    <style>
        #soletrando{
            font-weight: bold;
            font-size: 25px;
        }
    </style>
</head>
<form id="form1" runat="server">
    <div class="container">
    <header class="header clearfix">
        <nav>
        </nav>
        <h3 class="text-muted">Soletrando</h3>
    </header>

    <main role="main">
        <div class="jumbotron">
            <h1 class="display-3">Vamos Começar...</h1>
            <p class="lead">Digite uma palavra e ela terá suas sílabas separadas.</p>
            <asp:textbox id="palavra"  runat="server" MaxLength="28"  style="text-align: center" name="text"></asp:textbox><br>
            <audio src="" hidden class=speech></audio>
            <br />
            <input type="submit" value="Ouvir Texto" id="CMD_Buscar" runat="server" class="btn btn-lg btn-success say" />
            <div id="soletrando"></div>
        </div>

    </main>

    <footer class="footer">
        
    </footer>

</div> <!-- /container -->

</form>

<script language="javascript">
    function ff_soletrar(palavraSeparada) {
        document.getElementById('soletrando').innerHTML = '<br />Divisão Silábica: [' + palavraSeparada + ']';
        var text = palavraSeparada;
        responsiveVoice.speak(text, "Portuguese Female");
        text = encodeURIComponent(text);
        var url = "http://"
    }
</script>
