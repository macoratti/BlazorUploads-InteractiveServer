Enviando arquivos usando o rendermode InteractiveServer

Usamos o componente InputFile para ler os dados do arquivo do navegador. 
O inputfile renderiza um elemento HTML <input> do tipo file: 
(Onde por padrão, o usuário seleciona apenas um arquivo por vez)

<InputFile OnChange="@CarregaArquivos" />

Para permitir que o usuário carregue mais de um arquivos usamos o atributo multiple

<InputFile OnChange="@CarregaArquivos"  multiple />

Usamos tabém a interface IBrowserFile que representa os dados de um arquivo selecionado de um InputFile 
e que permite acessar as propriedades ContentType, LastModified, Name e Size
