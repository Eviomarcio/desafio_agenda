   <template>
    <div class="home-container">
      <h1 class="title">Contatos</h1>
  
      <div class="select-wrapper">
        <label for="contactListSelect">Selecione uma lista de contatos:</label>
        <select
          id="contactListSelect"
          v-model="selectedContactList"
          @change="fetchContacts"
        >
          <option disabled value="">Selecione uma opção</option>
          <option v-for="list in contactLists" :key="list.id" :value="list.id">
            {{ list.name }}
          </option>
        </select>
      </div>
  
      <div class="contact-list">
        <template v-if="contacts && contacts.length === 0">
          <p>Nenhum contato encontrado para esta lista.</p>
        </template>
        <div v-else class="grid-container">
          <div v-for="contact in contacts" :key="contact.phone" class="grid-item">
            <strong>{{ contact.name }}</strong><br />
            {{ contact.email }}<br />
            {{ contact.phone }}
          </div>
        </div>
      </div>

      <form @submit.prevent="createContact" class="form">
        <input v-model="newContact.name" placeholder="Nome" />
        <input v-model="newContact.email" placeholder="Email" />
        <input v-model="newContact.phone" placeholder="Telefone" />
        <button type="submit">Adicionar Contato</button>
      </form>
  
      <div class="buttons">
        <button @click="$router.push('/')">Voltar</button>
      </div>
    </div>
  </template>
  
  <script>
  import { ref, onMounted } from 'vue';
  import ApiService from '../services/ApiService';
  
  export default {
    name: 'ContactView',
    setup() {
      const apiService = new ApiService();
      const contacts = ref([]);
      const contactLists = ref([]);
      const selectedContactList = ref('');
      const newContact = ref({ name: '', email: '', phone: '' });
  
      const fetchContactLists = async () => {
        const response = await apiService.getAllContactList();
        contactLists.value = response.data;
        if (contactLists.value.length > 0) {
          selectedContactList.value = contactLists.value[0].id;
          fetchContacts();
        }
      };
  
      const fetchContacts = async () => {
        if (selectedContactList.value) {
          const response = await apiService.getAllContacts(selectedContactList.value);
          contacts.value = response.data;
        }
      };
        
      const createContact = async () => {
        if (newContact.value.name && newContact.value.email && newContact.value.phone) {
          const response = await apiService.createContact({
            ...newContact.value,
            idContactList: selectedContactList.value,
          });
          contacts.value.push(response.data);
          newContact.value = { name: '', email: '', phone: '' };
        }
      };
  
      onMounted(fetchContactLists);
  
      return {
        contacts,
        contactLists,
        selectedContactList,
        newContact,
        fetchContacts,
        createContact,
      };
    },
  };
  </script>
  
  <style scoped>
  .home-container {
    max-width: 900px;
    margin: auto;
    padding: 2rem;
    display: flex;
    flex-direction: column;
    gap: 2rem;
  }
  
  .title {
    font-size: 2rem;
    text-align: center;
    font-weight: bold;
  }
  
  .select-wrapper {
    margin: 1rem 0;
    width: 100%;
  }
  
  .select-wrapper label {
    display: block;
    font-weight: bold;
    margin-bottom: 0.5rem;
  }
  
  select {
    width: 100%;
    padding: 0.8rem;
    font-size: 1rem;
    border-radius: 6px;
    border: 1px solid #ccc;
  }
  
  .grid-container {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
    gap: 0.75rem;
  }
  
  .grid-item {
    padding: 0.75rem;
    border: 1px solid #ccc;
    border-radius: 6px;
    text-align: center;
  }
  
  .form {
    display: flex;
    flex-direction: column;
    gap: 1rem;
  }
  
  input {
    padding: 1rem;
    font-size: 1rem;
    border: 1px solid #ccc;
    border-radius: 8px;
  }
  
  button {
    padding: 1rem;
    font-size: 1rem;
    background-color: #3498db;
    color: white;
    border: none;
    border-radius: 8px;
    cursor: pointer;
    transition: background-color 0.3s ease;
  }
  
  button:hover {
    background-color: #2980b9;
  }
  
  .buttons {
    display: flex;
    justify-content: center;
  }
  </style>
  