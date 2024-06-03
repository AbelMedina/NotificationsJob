using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Job
    {
        public static void notificacion()
        {
            try
            {

                using (DL.administracionEntities context = new DL.administracionEntities())
                {
                    var query = context.ConsultaDispositivos().ToList();
                    if (query.Count != 0)
                    {
                        foreach (var dispositivo in query)
                        {
                            ML.body json = new ML.body();
                            //json.to = "dc9CVTmxS-GUUeE_umjyxu:APA91bHrsjg5vvhuQPCTsQXpmJo0_yctMd0nhD-lOvxYpmomNRekLTlKmO32us62x1eIwi6tbGtAtmHhixDEjRrDuXpzsIjK4HBwNrnWMOOeZeEa4yXdoNHcsTpfIz1gJJMOcqTYoagL";
                            json.to = dispositivo.Token;
                            json.notification = new ML.notification();
                            json.notification.title = "Reporte de tiempo";
                            json.notification.body = "No olvide enviar su reporte de tiempo.";  //
                            json.notification.sound = "default";
                            json.notification.icon = "icon_notif";
                            json.notification.color = "#24257d";
                            json.notification.badge = "2";
                            json.content_available = false;
                            json.priority = "High";
                            json.data = new ML.data();
                            json.data.existeNotificacion = true;
                            json.data.dataNotificacion = new ML.dataNotificacion();
                            json.data.dataNotificacion.Fecha = "Mar 23, 2023";
                            json.data.dataNotificacion.Hora = "1:26PM";
                            json.data.dataNotificacion.IdTiempo = 31756;
                            json.data.dataNotificacion.Leido = 0;
                            json.data.dataNotificacion.Mensaje = "Ya es quincena y aún no ha enviado su reporte de tiempo.";
                            json.data.dataNotificacion.Tipo = "Reporte-recordatorio";
                            json.data.dataNotificacion.Titulo = "Reporte de tiempo.";
                            string UrlBase = "https://fcm.googleapis.com/fcm/send";
                            using (HttpClient cliente = new HttpClient())
                            {
                                cliente.BaseAddress = new Uri(UrlBase);
                                string key = "key=AAAAUXOEKTU:APA91bHMIf7xjs03917UQImFirdyfaCGDs4cTphyuqlAiF1nmY8SGJ5wXbOBxlpjiq_C2LCAWeg0AhesoDhD2HjxDvguVsBf8f3zdpubCeAL7eMbSDTqD651PPXwj0IEnfEXDR8P6G2o";
                                //cliente.DefaultRequestHeaders.Clear();
                                //cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                cliente.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", key);
                                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key=",key);
                                var postTask = cliente.PostAsJsonAsync<ML.body>(UrlBase, json);
                                postTask.Wait();
                                var resultPost = postTask.Result;
                                if (resultPost.IsSuccessStatusCode)
                                {
                                    Console.WriteLine("Correcto");
                                }
                                else
                                {
                                    throw new ArgumentException(postTask.Result.ReasonPhrase);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
