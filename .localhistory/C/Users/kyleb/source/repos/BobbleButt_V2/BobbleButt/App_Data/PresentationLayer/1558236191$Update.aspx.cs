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
        protected void Page_Load(object sender, EventArgs e)
        {
            //Stops page from repopulating with previous data
            if (!IsPostBack)
            {
                //Request product value from viewProduct page depending on which product is selected
                string product = Request.QueryString["PassingValue"].ToString();
                //Change textbox text to equal product values of item selected
                productUpdateName.Text = GlobalData.productList[(Convert.ToInt32(product))].Name;
                productUpdateCategory.Text = GlobalData.productList[(Convert.ToInt32(product))].Category;
                productUpdateStock.Text = Convert.ToString(GlobalData.productList[(Convert.ToInt32(product))].Stock);
                productUpdateDescription.Text = GlobalData.productList[(Convert.ToInt32(product))].Description;
                productUpdatePrice.Text = Convert.ToString(GlobalData.productList[(Convert.ToInt32(product))].Price);
                productUpdateQuantity.Text = Convert.ToString(GlobalData.productList[(Convert.ToInt32(product))].Quantity);
            }
        }
        protected void updateConfirmBtn_Clicked(object sender, System.EventArgs e)
        {

            // Get value from viewRequest. Product value acts as index selector
            string product = Request.QueryString["PassingValue"].ToString();
            //Store updated values in variables
            string updateCategory = productUpdateCategory.Text;
            string updateName = productUpdateName.Text;
            int updateStock = Convert.ToInt32(productUpdateStock.Text);
            string updateDescription = productUpdateDescription.Text;
            double updatePrice = Convert.ToDouble(productUpdatePrice.Text);
            int updateQuantity = Convert.ToInt32(productUpdateQuantity.Text);
            string InsertImage = "img/" + Convert.ToString(updateFileUploadImg.FileName);
            //Checks to see if all the inputs are valid
            if (IsValid)
            {
                //Checks to see if file type is an image
                if (updateFileUploadImg.PostedFile.ContentType == "image/jpeg" || updateFileUploadImg.PostedFile.ContentType == "image/png" || updateFileUploadImg.PostedFile.ContentType == "image/jpg")
                {
                    //Make error message invisible if file type is correct
                    updateImageFileError.Visible = false;
                    //Save image to project
                    updateFileUploadImg.SaveAs(Server.MapPath("~/img/" + updateFileUploadImg.FileName));
                    //Change dummy data in global data to equal to updated data 
                    GlobalData.productList[Convert.ToInt32(product)].Category = updateCategory;
                    GlobalData.productList[Convert.ToInt32(product)].Name = updateName;
                    GlobalData.productList[Convert.ToInt32(product)].Stock = updateStock;
                    GlobalData.productList[Convert.ToInt32(product)].Description = updateDescription;
                    GlobalData.productList[Convert.ToInt32(product)].Price = updatePrice;
                    GlobalData.productList[Convert.ToInt32(product)].Quantity = updateQuantity;
                    GlobalData.productList[Convert.ToInt32(product)].Image = InsertImage;
                    Response.Redirect("ViewProduct.aspx");
                }
                else
                {
                    //make error message visbile
                    updateImageFileError.Visible = true;
                }
            }
            
        }
    }
}