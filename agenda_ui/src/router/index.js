import { createRouter, createWebHistory } from 'vue-router'
import contactListView from '../views/contactListView.vue'
import contactView from '../views/contactView.vue'

const routes = [
  { path: '/', redirect: '/contactList' },
  { path: '/contactList', component: contactListView },
  { path: '/contact/:contactListId', component: contactView, props: true }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
