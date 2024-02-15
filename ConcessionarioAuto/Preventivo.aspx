<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Preventivo.aspx.cs" Inherits="ConcessionarioAuto.Preventivo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Preventivo Auto</title>
     <style>
        
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

        .container {
            display: flex;
            justify-content: space-between;
            align-items: flex-start;
        }

        .car-details {
            width: 50%;
        }

        .options {
            width: 40%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="car-details">
                <!-- DropdownList per la selezione dell'auto-->
                <label for="ddlCars">Seleziona Auto:</label>
                <asp:DropDownList ID="ddlCars" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCars_SelectedIndexChanged">
                    <asp:ListItem Text="Auto1" Value="Auto1"/>
                    <asp:ListItem Text="Auto2" Value="Auto2"/>
                    <asp:ListItem Text="Auto3" Value="Auto3"/>
                    <asp:ListItem Text="Auto4" Value="Auto4"/>
                    <asp:ListItem Text="Auto5" Value="Auto5"/>
                </asp:DropDownList>

                <!-- Immagine e prezzo dell'auto selezionata-->
                <asp:Image ID="imgCar" runat="server" Visible="false" />
                <asp:Label runat="server" ID="lblCarPrice" Text="" Visible="false"></asp:Label>
            </div>

            <div class="options">
                <!--CheckBoxList per gli optional-->
                <label>Optional:</label>
                <asp:CheckBoxList ID="cblOptions" runat="server">
                    <asp:ListItem Text="Optional1" Value="Optional1" />
                    <asp:ListItem Text="Optional2" Value="Optional2" />
                    <asp:ListItem Text="Optional3" Value="Optional3" />
                    <asp:ListItem Text="Optional4" Value="Optional4" />
                </asp:CheckBoxList>

                <!--TextBox per il numero di anni di garanzia-->
                <label for="txtWarranty">Anni di garanzia: </label>
                <asp:TextBox ID="txtWarranty" runat="server"></asp:TextBox>
            </div>
        </div>

        <!--Pulsante per calcolare il preventivo-->
        <asp:Button ID="btnCalcolaPreventivo" runat="server" Text="Calcola preventivo"  OnClick="btnCalcolaPreventivo_Click" />

        <!--GridView per mostrare il riepilogo del preventivo-->
        <asp:GridView ID="gvPreventivo" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" />
                <asp:BoundField DataField="Importo" HeaderText="Importo (EUR)"  DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
