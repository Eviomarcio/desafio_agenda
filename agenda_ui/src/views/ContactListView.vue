<template>
    <div>
      <h1>Agendas</h1>
  
      <div v-if="loading">Carregando agendas...</div>
      <div v-else-if="contactList.length === 0">Nenhuma agenda encontrada.</div>
      <div v-else>
        <ContactList
          v-for="agenda in contactList"
          :key="agenda.id"
          :agenda="agenda"
          @open-contact="toContact"
          @edit="editcontactList"
          @delete="deletecontactList"
        />
      </div>
    </div>
  </template>
  
  <script>
  import { getContactList } from '../api/contactList'
  import ContactListCard from '../components/contactListCard.vue'
  
  export default {
    name: 'ContactListView',
    components: { ContactListCard },
    data() {
      return {
        contactLists: [],
        loading: true
      }
    },
    async mounted() {
      this.contactList = await getContactList()
      this.loading = false
    },
    methods: {
      toContact(contactListId) {
        this.$router.push(`/contact/${contactListId}`)
      },
      editcontactList(contactList) {
        alert(`Editar agenda: ${contactList.name}`)
      },
      deletecontactList(id) {
        alert(`Excluir agenda com id ${id}`)
      }
    }
  }
  </script>
  