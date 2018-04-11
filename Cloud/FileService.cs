using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
  public  class FileService
    {
        public void Create(FileBase userr)
        {
            using (CloudModel context = new CloudModel())
            {
                context.FileBase.Add(userr);
                context.SaveChanges();
            }
        }

        public List<FileBase> SelectAll()
        {
            List<FileBase> cat;
            using (CloudModel context = new CloudModel())
            {
                cat = context.FileBase.ToList();
            }
            return cat;
        }

        public FileBase Select(int id)
        {
            FileBase result = new FileBase();
            using (CloudModel context = new CloudModel())
            {
                List<FileBase> temp = context.FileBase.ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].Id == id)
                    {
                        result = temp[i];
                    }
                }
            }
            return result;
        }

        public void Update(FileBase product)
        {


            using (CloudModel context = new CloudModel())
            {
                context.Entry(product).State = EntityState.Modified;
            }

        }

        public void Delete(int id)
        {
            FileBase result = new FileBase();
            using (CloudModel context = new CloudModel())
            {
                List<FileBase> temp = context.FileBase.ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].Id == id)
                    {
                        context.FileBase.Remove(temp[i]);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
