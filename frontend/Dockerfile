# client/Dockerfile
FROM node:20 AS build
WORKDIR /app
COPY frontend/package*.json ./
RUN npm ci
COPY client/ ./
RUN npm run build -- --mode production

FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]