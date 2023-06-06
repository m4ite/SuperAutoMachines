using System.Linq;
using System.Collections.Generic;

public class Jogo
{
    // SingleTon para permitir botão de reiniciar/resetar     
    private Jogo() { }
    private static Jogo crr = null;
    public static Jogo Current => crr;

    // Seta valores iniciais
    private int Round { get; set; } = 0;
    private int VidaInicial { get; set; }
    private int MoedasInicias { get; set; }
    private int LimiteMaquinasMercado { get; set; }
    private Jogador Jogador = null;
    private Mercado Mercado = null;
    private Batalha Batalha = null;
    private PecaArgs PecaArgs = null;
    private JogadorArgs JogadorArgs = null;
    private BatalhaArgs BatalhaArgs = null;
    private MercadoArgs MercadoArgs = null;

    // Rodar o Jogo
    public void Executar()
    {   
        this.MercadoArgs.Jogador = this.Jogador;
        this.MercadoArgs.LimiteMaquinasMercado = this.LimiteMaquinasMercado;
        this.Mercado = new Mercado();

    }

    // Define como vai funcionar o Builder
    public class JogoBuilder
    {
        private Jogo jogo = new Jogo();

        public Jogo Build()
            => this.jogo;

        public JogoBuilder SetVidaInicial(int vida)
        {
            jogo.VidaInicial = vida;
            return this;
        }

        public JogoBuilder SetMoedasIniciais(int moedas)
        {
            jogo.MoedasInicias = moedas;
            return this;
        }

        public JogoBuilder SetLimiteMaquinasMercado(int maquinas)
        {
            jogo.LimiteMaquinasMercado = maquinas;
            return this;
        }

        public JogoBuilder SetArgs()
        {
            jogo.PecaArgs = new PecaArgs();
            jogo.JogadorArgs = new JogadorArgs();
            jogo.MercadoArgs = new MercadoArgs();
            jogo.BatalhaArgs = new BatalhaArgs();
            return this;
        }
    }
    public static JogoBuilder GetBuilder()
        => new JogoBuilder();

    public static void New(JogoBuilder builder)
        => crr = builder.Build();
}

