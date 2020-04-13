using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Plugins
{
    public class MySqlUser : iUserPlugin
    {
        //Attributes
        MySqlConnection dcUser;


        //Constructor
        public MySqlUser()
        {
            this.dcUser = new MySqlConnection("server=142.93.114.73;database=atsweeney;user=atsweeney;password=letmein");

            try
            {
                this.dcUser.Open();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        //Methods
        public void Close()
        {
            this.dcUser.Close();
        }

        public void Create(iEntity obj)
        {
            User user = (User)obj;

            try
            {
                DateTime now = DateTime.Now;

                string sql = "INSERT INTO users (sys_id, email, dttm_registration, dttm_last_login) VALUES ('"
                    + user.Id + "', '"
                    + user.Email + "', '"
                    + now.ToString("yyyy-MM-dd HH:mm:ss") + "', '"
                    + now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                
                MySqlCommand cmd = new MySqlCommand(sql, this.dcUser);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable ReadAll()
        {
            try
            {
                string sql = "SELECT * FROM users";
                MySqlDataAdapter daUsers = new MySqlDataAdapter(sql, this.dcUser);
                MySqlCommandBuilder cbUsers = new MySqlCommandBuilder(daUsers);
                DataSet dsUsers = new DataSet();

                daUsers.Fill(dsUsers);

                ArrayList users = new ArrayList();

                foreach(DataRow dtRow in dsUsers.Tables[0].Rows)
                {
                    users.Add(ConvertDataRowToUser(dtRow));
                }

                return users;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public iEntity ReadById(Guid Id)
        {
            try
            {
                string sql = "SELECT * FROM users WHERE users.sys_id = '" + Id.ToString() + "'";
                MySqlDataAdapter daUser = new MySqlDataAdapter(sql, this.dcUser);
                MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
                DataSet dsUser = new DataSet();

                daUser.Fill(dsUser, "users");

                DataRow row = dsUser.Tables[0].Rows[0];

                return ConvertDataRowToUser(row);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public iEntity ReadByUserEmail(string email)
        {
            try
            {
                string sql = "SELECT * FROM users WHERE users.email = '" + email.ToString() + "'";
                MySqlDataAdapter daUser = new MySqlDataAdapter(sql, this.dcUser);
                MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
                DataSet dsUser = new DataSet();

                daUser.Fill(dsUser, "users");

                DataRow row = dsUser.Tables[0].Rows[0];

                return ConvertDataRowToUser(row);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Update(iEntity obj)
        {
            User user = (User)obj;

            this.Delete(user);
            this.Create(user);
        }

        public void Delete(iEntity obj)
        {
            User user = (User)obj;

            try
            {
                string sql = "DELETE FROM users WHERE users.email = '" + user.Email + "'";
                
                MySqlCommand cmd = new MySqlCommand(sql, this.dcUser);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private User ConvertDataRowToUser(DataRow row)
        {
            User user = new User();

            user.Id = new Guid(row["sys_id"].ToString());
            user.ChangeEmail(row["email"].ToString());
            user.RegisterDTTM = (DateTime)row["dttm_registration"];
            user.LastLoginDTTM = (DateTime)row["dttm_last_login"];

            return user;
        }
    }
}