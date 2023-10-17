using System.ComponentModel;

namespace Impar.BackEnd.Evaluation.Model.Enum
{
    public enum EStatusMensagem
    {
        [Description("Não Enviado")]
        NaoEnviado = 0,

        [Description("Aguardando Envio")]
        AguardandoEnvio = 1,

        [Description("Enviado")]
        Enviado = 2,
    }
}
