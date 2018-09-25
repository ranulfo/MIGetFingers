using System;
using System.Collections.Generic;
using System.Text;
using System.Net;   



namespace MIGetFingers
{
    public class Fingers
    {
        
        public bool GetFinger(ref object template, long nu_ric,  int position)
        {
            byte[] tem =null;
            try
            {
                string url = string.Format("http://10.200.96.20/Mini_Portal/Handler1.ashx?file=23-5-2012-103848template-{0}_RG-{1}.bin", position, nu_ric);
                
                using (WebClient webClient = new WebClient())
                {
                    //webClient.Headers["User-Agent"] = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.2.6) Gecko/20100625 Firefox/3.6.6 (.NET CLR 3.5.30729)";
                    //webClient.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    //webClient.Headers["Accept-Language"] = "en-us,en;q=0.5";
                    
                    
                    try
                    {
                        tem = webClient.DownloadData(url);
                    }
                    catch (Exception e)
                    {
                        template = null;

                        if (e.Message.Contains("(500) Internal Server Error!.") || e.Message.Contains("(500) Erro Interno do Servidor!."))//provável erro de template, afisid = -200                        
                        {
                            return false;
                        }
                        System.Windows.Forms.MessageBox.Show("Problemas no download do template, talvez seja necessário habilitar conexão sem proxy para o IP 10.200.96.20, descrição do erro: " + e.Message);                        
                        return false;
                    }

                }
                
            }
            catch
            {
                template = null;
                return false;
            }
            if (tem == null || tem.GetLength(0) == 0 || System.Text.Encoding.ASCII.GetString(tem) == "INVALID") 
            {
                return false;
            }
            template = (object)tem;
            return true;

        }

                

    }
}
