using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConcessionarioAuto
{
    public partial class Preventivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                // Inizializza il dropdown delle auto al caricamento della pagina
                BindCarDropdown();
            }
        }

        protected void ddlCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCar = ddlCars.SelectedValue;
            imgCar.ImageUrl = $"Images/{selectedCar}.jpeg"; 
            lblCarPrice.Text = $"Prezzo di base: {GetCarPrice(selectedCar):C}";
            imgCar.Visible = true;
            lblCarPrice.Visible = true;
        }

        protected void btnCalcolaPreventivo_Click(object sender, EventArgs e)
        {
            //Calcola e mostra il riepilogo del preventivo
            DataTable dtPreventivo = CreatePreventivoTable();
            DataRow row;

            //Aggiungi il prezzo di base
            string selectedCar = ddlCars.SelectedValue;
            decimal carPrice = GetCarPrice(selectedCar);
            row = dtPreventivo.NewRow();
            row["Descrizione"] = "Prezzo di base";
            row["Importo"] = carPrice;
            dtPreventivo.Rows.Add(row);

            // Aggiungi gli optional
            foreach (ListItem option in cblOptions.Items)
            {
                if (option.Selected)
                {
                    row = dtPreventivo.NewRow();
                    row["Descrizione"] = $"Optional: {option.Text}";
                    row["Importo"] = 50.00M; 
                    dtPreventivo.Rows.Add(row);
                }
            }

            // Aggiungi la garanzia
            int years = 0;
            if (int.TryParse(txtWarranty.Text, out years))
            {
                decimal warrantyCost = years * 120.00M;
                row = dtPreventivo.NewRow();
                row["Descrizione"] = $"Garanzia ({years} anni)";
                row["Importo"] = warrantyCost;
                dtPreventivo.Rows.Add(row);
            }

            //Calcola il totale complessivo
            decimal totalAmount = carPrice;
            foreach (DataRow r in dtPreventivo.Rows)
            {
                totalAmount += Convert.ToDecimal(r["Importo"]);
            }

            //Aggiungi il totale complessivo
            row = dtPreventivo.NewRow();
            row["Descrizione"] = "Totale Complessivo";
            row["Importo"] = totalAmount;
            dtPreventivo.Rows.Add(row);

            //Mostra il riepilogo nel gridView
            gvPreventivo.DataSource = dtPreventivo;
            gvPreventivo.DataBind();

        }

        private void BindCarDropdown()
        {
            // Popola il dropdownlist delle auto
            ddlCars.Items.Clear();
            ddlCars.Items.Add(new System.Web.UI.WebControls.ListItem("Auto1", "Auto1"));
            ddlCars.Items.Add(new System.Web.UI.WebControls.ListItem("Auto2", "Auto2"));
            ddlCars.Items.Add(new System.Web.UI.WebControls.ListItem("Auto3", "Auto3"));
            ddlCars.Items.Add(new System.Web.UI.WebControls.ListItem("Auto4", "Auto4"));
            ddlCars.Items.Add(new System.Web.UI.WebControls.ListItem("Auto5", "Auto5"));
            // Aggiungi altre auto se necessario
        }

        private decimal GetCarPrice(string carModel)
        {
            // Metodo fittizio per ottenere il prezzo dell'auto, personalizza secondo necessità
            if (carModel == "Auto1")
            {
                return 25000.00M;
            }
            else if (carModel == "Auto2")
            {
                return 30000.00M;
            }
            else if (carModel == "Auto3")
            {
                return 30300.00M;
            }
            else if (carModel == "Auto4")
            {
                return 50000.00M;
            }
            else if (carModel == "Auto5")
            {
                return 80000.00M;
            }
            return 0.00M;
        }
        private DataTable CreatePreventivoTable()
        {
            // Crea una DataTable per il riepilogo del preventivo
            DataTable dt = new DataTable();
            dt.Columns.Add("Descrizione");
            dt.Columns.Add("Importo", typeof(decimal));
            return dt;
        }
    }
}