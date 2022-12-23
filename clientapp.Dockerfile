FROM node:19-alpine AS build
WORKDIR /app
COPY . .
WORKDIR /app/home.clientapp
RUN npm ci 
RUN npm run build

FROM nginx:alpine AS final
ENV NODE_ENV production

COPY --from=build /app/home.clientapp/build /var/www/html
COPY home.clientapp/nginx.conf /etc/nginx/conf.d/default.conf


CMD ["nginx", "-g", "daemon off;"]
