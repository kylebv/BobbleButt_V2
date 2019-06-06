using BobbleButt.BusinessLayer;
using BobbleButt.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class Update : System.Web.UI.Page
    {
        protected Product p;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Stops page from repopulating with previous data
            if (!IsPostBack)
            {
                //Request product value from viewProduct page depending on which product is selected
                string product = Request.QueryString["product"];
                int productID = 0;
                try
                {
                    productID = Convert.ToInt32(product);
                }
                catch { }
                p = QueryClass.GetProduct(productID);
                //Change textbox text to equal product values of item selected
                productUpdateName.Text = p.Name;
                productUpdateCategory.Text = p.Category;
                productUpdateStock.Text = p.Stock.ToString();
                productUpdateDescription.Text = p.Description;
                productUpdatePrice.Text = p.Price.ToString("F");
                pID.Text = p.ID.ToString();
                fileName.Text = "Filename before the change: "+p.Image;
            }
        }
        protected void updateConfirmBtn_Clicked(object sender, System.EventArgs e)
        {
            int productID = 0;
            try
            {
                productID = Convert.ToInt32(pID.Text);
            }
            catch { }
            p = QueryClass.GetProduct(productID);
            //Store updated values in variables
            string updateCategory = productUpdateCategory.Text;
            string updateName = productUpdateName.Text;
            int updateStock = Convert.ToInt32(productUpdateStock.Text);
            string updateDescription = productUpdateDescription.Text;
            double updatePrice = Convert.ToDouble(productUpdatePrice.Text);
            string InsertImage;
            if (updateFileUploadImg.HasFile)
            {
                InsertImage = "../img/" + Convert.ToString(updateFileUploadImg.FileName);
            }
            else
            {
                InsertImage = p.Image;
            }
            //Checks to see if all the inputs are valid
            if (IsValid)
            {
                if (updateFileUploadImg.HasFile) {
                    //Checks to see if file type is an image
                    if (updateFileUploadImg.PostedFile.ContentType == "image/jpeg" || updateFileUploadImg.PostedFile.ContentType == "image/png" || updateFileUploadImg.PostedFile.ContentType == "image/jpg")
                    {
                        //Make error message invisible if file type is correct
                        updateImageFileError.Visible = false;
                        //Save image to project
                        updateFileUploadImg.SaveAs(Server.MapPath("~/img/" + updateFileUploadImg.FileName));
                    }
                    else
                    {
                        //make error message visbile
                        updateImageFileError.Visible = true;
                    }
                }
                if (!updateImageFileError.Visible)
                {
                    p.Category = updateCategory;
                    p.Name = updateName;
                    p.Stock = updateStock;
                    p.Description = updateDescription;
                    p.Price = updatePrice;
                    p.Quantity = 1;
                    p.Image = InsertImage;
                    QueryClass.UpdateProduct(p);
                    Response.Redirect("ManageProducts.aspx");
                }
            }
            
        }
    }
}