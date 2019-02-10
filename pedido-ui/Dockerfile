# Stage 1
FROM node:10.15.1-alpine as node
WORKDIR /usr/src/app
COPY ["pedido-ui/package*.json", "./"]
RUN npm install
COPY ["pedido-ui/.", "."]
RUN npm run build

# Stage 2
FROM nginx:1.15.8-alpine
COPY ["pedido-ui/nginx.conf", "/etc/nginx/conf.d/default.conf"]
COPY --from=node /usr/src/app/dist/pedido-ui /usr/share/nginx/html
