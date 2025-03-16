# Step 1: Build your frontend application
FROM node:20-alpine as build

WORKDIR /app

# Copy package files and install dependencies
COPY frontend/package*.json ./
RUN npm install  # Install dependencies first

# Copy the source code and build the app
COPY frontend/ ./
RUN npm run build  # Run build command (vite build)

# Step 2: Serve the built frontend using Nginx
FROM nginx:alpine

# Copy the build output to Nginx's public directory
COPY --from=build /app/dist /usr/share/nginx/html 

# Copy custom Nginx configuration
COPY clean-nginx.conf /etc/nginx/nginx.conf

# Expose port 80
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
