import { createRouter, createWebHistory } from 'vue-router';
import ContactListView from './components/ContactListView.vue';
import ContactView from './components/ContactView.vue';
import Home from './components/HomeView.vue';

const routes = [
    { path: '/', component: Home },
    { path: '/contact', component: ContactView },
    { path: '/contactList', component: ContactListView },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;