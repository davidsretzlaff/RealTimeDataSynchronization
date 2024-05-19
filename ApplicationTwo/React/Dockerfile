# Use uma imagem base com o Node.js instalado
FROM node:alpine

# Defina o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie o arquivo package.json para o contêiner
COPY package.json .

# Instale as dependências
RUN yarn install --frozen-lockfile

# Copie todos os arquivos do diretório atual para o contêiner
COPY . .

# Compile o aplicativo React
RUN yarn build

# Exponha a porta 3000 para acessar o aplicativo
EXPOSE 3000

# Comando para iniciar o servidor de desenvolvimento do React
CMD ["yarn", "start"]
