import { createApp } from 'vue';
import './style.css';
import App from './App.vue';
import router from './router'; // Import the router

// Add API service classes for managing contacts and contact lists
import ApiService from './services/ApiService';

// Initialize the API service
const apiService = new ApiService();

// Example usage of the API service
apiService.createContactList({ name: 'Familia' }).then(response => {
  console.log(response);
});

// Use the router in the Vue app
createApp(App).use(router).mount('#app');
