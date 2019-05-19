using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BobbleButt
{
    public partial class ManageItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ManageInsertsCancelBtn_Click(object sender, EventArgs e)
        {        
        }
        protected void ManageInsertsSubmitBtn_Click(object sender, EventArgs e)
        {
            //Get user input from textboxes and put them into variables
            string InsertCategory = manageInsertCategory.Text ;
            string InsertName = manageInsertName.Text;
            int InsertStock = Convert.ToInt32(manageInsertStock.Text);
            string InsertDescription = manageInsertDescription.Text;
            double InsertPrice = Convert.ToDouble(manageInsertPrice.Text);
            int InsertQuantity = Convert.ToInt32(manageInsertQuantity.Text);
            string InsertImage = "img/" + Convert.ToString(FileUploadImg.FileName);
            

            // Checks to see if all fields  of user input are valid
            if (IsValid)
            {
                /* Author:
                Use:  To allow for an image to be uploaded and check for correct file type
                Website Name: ASP.net webform Tutorials
                Website Url: https://asp.net-tutorials.com/controls/file-upload-control 
                Date: 11/04/19
                Page Used: ManageItems.aspx, ManageItems.aspx.cs
                */
                //Check if image file is a certain type
                if (FileUploadImg.PostedFile.ContentType == "image/jpeg" || FileUploadImg.PostedFile.ContentType == "image/png" || FileUploadImg.PostedFile.ContentType == "image/jpg")
                {
                    //Error text is switched to invisible
                    insertImageFileError.Visible = false;
                    /* Author: Kudvenkat
                        Use: Used to upload an image into the project 
                        Website Name: Fileupload control in asp.net Part 30 (4.40 seconds)
                        Website Url: https://www.youtube.com/watch?v=irF6Zomjxwc&feature=youtu.be
                        Date: 11/04/19
                        Pahe used: ManageItems.aspx.cs
                         */
                    //Save image into project
                    FileUploadImg.SaveAs(Server.MapPath("~/img/" + FileUploadImg.FileName));
                    //Add data inserted in globalData as a new product
                    GlobalData.productList.Add(new Product(InsertCategory, InsertName, InsertStock, InsertDescription, InsertPrice, InsertImage, InsertQuantity));
                    Response.Redirect("ManageItems.aspx");
                }
                else
                {
                    //Display error message by making text visible
                    insertImageFileError.Visible = true;
                }
            }
        
        }
        protected void insertUploadBtn_Click(object sender, EventArgs e)
        {   
        }
    }
}