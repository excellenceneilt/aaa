using Infra.DataAccess.Contracts;
using Infra.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repositories
{

    public class ClientRepository : MasterRepository, IClientRepository
    {


        public int Add(Client entity)
        {//Ejemplo de una transacción con varios parámetros usando un procedimiento almacenado:
         //Agregar un nuevo usuario.

            var parameters = new List<SqlParameter>();//Crear una lista para los parámetros de la transacción.
            
            parameters.Add(new SqlParameter("@firstName", entity.FirstName));
            parameters.Add(new SqlParameter("@lastName", entity.LastName));
            parameters.Add(new SqlParameter("@email", entity.Email));
            

            //Ejecutar el método ExecuteNonQuery de la clase MasterRepository para realizar una transacción de insertar,
            //y enviar los parámetros necesarios (Comando de texto, parámetros y tipo de comando).
            return ExecuteNonQuery("AddClient", parameters, CommandType.StoredProcedure);
        }
        public int Edit(Client entity)
        {//Ejemplo de una transacción con varios parámetros usando un procedimiento almacenado:
         //Editar usuario.

            var parameters = new List<SqlParameter>();//Crear una lista para los parámetros de la transacción.
            parameters.Add(new SqlParameter("@id", entity.Id));
            
            parameters.Add(new SqlParameter("@firstName", entity.FirstName));
            parameters.Add(new SqlParameter("@lastName", entity.LastName));
            parameters.Add(new SqlParameter("@email", entity.Email));
 

            //Ejecutar el método ExecuteNonQuery de la clase MasterRepository para realizar una transacción de actualizar,
            //y enviar los parámetros necesarios (Comando de texto, parámetros y tipo de comando).
            return ExecuteNonQuery("EditClient", parameters, CommandType.StoredProcedure);
        }

        public int Remove(Client entity)
        {//Ejemplo de una transacción con un solo parámetro usando un comando Transact-SQL:
         //Eliminar usuario.

            string sqlCommand = "delete from Clients where id=@id";//Comando de tipo texto (Transact-SQL)
            return ExecuteNonQuery(sqlCommand, new SqlParameter("@id", entity.Id), CommandType.Text);
        }


        public int AddRange(List<Client> clients)
        {//Ejemplo de una transacción masiva usando un procedimiento almacenado:
         //Agregar varios usuarios.

            var transactions = new List<BulkTransaction>();//Crear una lista genérica para las transacciones.

            foreach (var client in clients)//Recorrer la lista de usuarios y agregar la instrucciones a la lista de transacciones.
            {
                var trans = new BulkTransaction();//Crear un objeto de transacción.
                var parameters = new List<SqlParameter>();//Crear una lista para los parámetros de la transacción.
                //En este caso de una transacción masiva, es conveniente especificar el tipo de dato del parámetro.
                parameters.Add(new SqlParameter("@firstName", client.FirstName) { SqlDbType = SqlDbType.NVarChar });
                parameters.Add(new SqlParameter("@lastName", client.LastName) { SqlDbType = SqlDbType.NVarChar });
               
                parameters.Add(new SqlParameter("@email", client.Email) { SqlDbType = SqlDbType.NVarChar });
               
                trans.CommandText = "AddClient";//Establecer el comando de texto(En este caso un procedimiento almacenado).
                trans.Parameters = parameters;//Establecer los parametros de la instrucción (Comando de texto).

                transactions.Add(trans);//Agregar la transacción a la lista de transacciones.
            }
            //Puede continuar agregando más transacciones a otras tablas a la lista genérica de transacciones.

            //Finalmente ejecutar todas las instrucciones de la lista de transacciones usando el método
            //BulkExecuteNonQuery de la clase base MasterRepository, enviar los parámetros necesarios
            //(Lista de transacciones y el tipo de comando.)
            return BulkExecuteNonQuery(transactions, CommandType.StoredProcedure);
        }


        public int RemoveRange(List<Client> clients)
        {//Ejemplo de una transacción masiva usando un comando Transact-SQL:
         //Eliminar varios usuarios.

            var transactions = new List<BulkTransaction>();

            foreach (var client in clients)
            {
                var trans = new BulkTransaction();
                trans.CommandText = "delete from Clients where id=@id";
                trans.Parameters = new List<SqlParameter>{
                   new SqlParameter("@id", client.Id){SqlDbType=SqlDbType.Int}};

                transactions.Add(trans);
            }
            return BulkExecuteNonQuery(transactions, CommandType.Text);
        }



        public Client GetSingle(string value)
        {//Ejemplo de una consulta usando un comando Transact-SQL con un parámetro:
         //Obtener un usuario según el valor espeficicado (Buscar).

            string sqlCommand;
            DataTable table;
            int idClient;

            bool isNumeric = int.TryParse(value, out idClient);//Determinar si el parámetro valor es un numero entero.
            if (isNumeric)//Si el valor es un número, realizar la consulta usando el id del usuario.
            {
                sqlCommand = "select *from Clients where id= @idClient";
                table = ExecuteReader(sqlCommand, new SqlParameter("@idClient", idClient), CommandType.Text);
            }
            else //Caso contrario, realizar la consulta usando el nombre de usuario o correo electrónico.
            {
                sqlCommand = "select *from Clients where firstName= @findValue or email=@findValue";
                table = ExecuteReader(sqlCommand, new SqlParameter("@findValue", value), CommandType.Text);
            }

            if (table.Rows.Count > 0)//Si la consulta tiene resultado
            {
                var client = new Client();//Crear un objeto usuario y asignar los valores.
                foreach (DataRow row in table.Rows)
                {
                    client.Id = Convert.ToInt32(row[0]);
                    client.FirstName = row[1].ToString();
                    client.LastName = row[2].ToString();
                    client.Email = row[3].ToString();
                    
                }
                //Opcionalmente desechar la tabla para liberar memoria.
                table.Clear();
                table = null;

                return client;//Retornar usuario encontrado.
            }
            else//Si la consulta no fué exitosa, retornar nulo.
                return null;



        }


        public IEnumerable<Client> GetAll()
        {
            var clientList = new List<Client>();
            var table = ExecuteReader("SelectAllClients", CommandType.StoredProcedure);

            foreach (DataRow row in table.Rows)
            {
                var client = new Client();
                client.Id = Convert.ToInt32(row[0]);
                client.FirstName = row[1].ToString();
                client.LastName = row[2].ToString();
                client.Email = row[3].ToString();
                

                clientList.Add(client);
            }
            table.Clear();
            table = null;

            return clientList;
        }


        public IEnumerable<Client> GetByValue(string value)
        {
            var clientList = new List<Client>();
            var table = ExecuteReader("SelectClient", new SqlParameter("@findValue", value), CommandType.StoredProcedure);

            foreach (DataRow row in table.Rows)
            {
                var client = new Client();
                client.Id = Convert.ToInt32(row[0]);
                client.FirstName = row[1].ToString();
                client.LastName = row[2].ToString();
                client.Email = row[3].ToString();


                clientList.Add(client);
            }
            table.Clear();
            table = null;

            return clientList;
        }



    }




}
