using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
   public class UserrService
    {
        public void Create(Userr userr)
        {
            using (CloudModel context = new CloudModel())
            {
                context.Userr.Add(userr);
                context.SaveChanges();
            }
        }

        public List<Userr> SelectAll()
        {
            List<Userr> cat;
            using (CloudModel context = new CloudModel())
            {
                cat = context.Userr.ToList();
            }
            return cat;
        }

        public Userr Select(int id)
        {
            Userr result = new Userr();
            using (CloudModel context = new CloudModel())
            {
                List<Userr> temp = context.Userr.ToList();
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

        public void Update(Userr product)
        {


            using (CloudModel context = new CloudModel())
            {
                context.Entry(product).State = EntityState.Modified;
            }

        }

        public void Delete(int id)
        {
            Userr result = new Userr();
            using (CloudModel context = new CloudModel())
            {
                List<Userr> temp = context.Userr.ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].Id == id)
                    {
                        context.Userr.Remove(temp[i]);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
