using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Text;
using aspMvc.Models;

namespace aspMvc.Controllers
{
    public class MyApiController : ApiController
    {
        Contact[] contacts = new Contact[] 
         { 
             new Contact(){ ID=1, Age=23, Birthday=Convert.ToDateTime("1977-05-30"), Name="情缘", Sex="男"},
             new Contact(){ ID=2, Age=55, Birthday=Convert.ToDateTime("1937-05-30"), Name="令狐冲", Sex="男"},
             new Contact(){ ID=3, Age=12, Birthday=Convert.ToDateTime("1987-05-30"), Name="郭靖", Sex="男"},
             new Contact(){ ID=4, Age=18, Birthday=Convert.ToDateTime("1997-05-30"), Name="黄蓉", Sex="女"},
         };

        /// <summary>
        /// /api/Contact
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetListAll()
        {
            return contacts;
        }
        [HttpPost]
        public IEnumerable<Contact> GetListAll(string str)
        {
            return contacts;
        }
        /// <summary>
        /// /api/Contact/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact GetContactByID(int id)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(item => item.ID == id);
            if (contact == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return contact;
        }

        /// <summary>
        /// 根据性别查询
        /// /api/Contact?sex=女
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public IEnumerable<Contact> GetListBySex(string sex)
        {
            return contacts.Where(item => item.Sex == sex);
        }

        //[HttpPost]
        //public async Task<HttpResponseMessage> UploadFile()
        //{


        //    var context = new StorageContext();

        //    // Check if the request contains multipart/form-data. 
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        throw new System.Web.Http.HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //    }

        //    // Get and create the container 
        //    var blobContainer = context.BlobClient.GetContainerReference(CONTAINER);

        //    // Create the "images" container if it doesn't already exist.
        //    if (await blobContainer.CreateIfNotExistsAsync())
        //    {
        //        // Enable public access on the newly created "images" container
        //        await blobContainer.SetPermissionsAsync(
        //            new BlobContainerPermissions
        //            {
        //                PublicAccess =
        //                    BlobContainerPublicAccessType.Blob
        //            });


        //    }


        //    #region [MultipartMemoryStreamProvider]

        //    try
        //    {
        //        if (Request.Content.IsMimeMultipartContent())
        //        {

        //            var streamProvider = new MultipartMemoryStreamProvider();
        //            await Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
        //            {
        //                foreach (var fileContent in streamProvider.Contents)
        //                {

        //                    Stream stream = fileContent.ReadAsStreamAsync().Result;
        //                    var fileName = fileContent.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
        //                    var blob = blobContainer.GetBlockBlobReference(fileName);


        //                    blob.UploadFromStream(stream);



        //                }
        //            });
        //        }


        //        var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //       // response.Content = new StringContent(id.ToJSON(), Encoding.UTF8, "application/json");

        //        return response;
        //    }
        //    catch (System.Exception e)
        //    {
        //        // return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        //    }
        //    #endregion


        //}
    }

}
