using System;

var builder = Jogo.GetBuilder();

builder.SetArgs()
    .SetVidaInicial(5)
    .SetMoedasIniciais(10)
    .SetLimiteMaquinasMercado(5);

Jogo.New(builder);

Jogo.Current.Executar();
