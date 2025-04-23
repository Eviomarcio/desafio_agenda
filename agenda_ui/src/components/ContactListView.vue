  <template>
    <div class="home-container">
      <h1 class="title">Listas de Contatos</h1>
  
      <div class="grid-container">
        <div v-for="list in contactLists" :key="list.id" class="grid-item">
          {{ list.name }}
        </div>
      </div>
  
      <form @submit.prevent="createContactList" class="form">
        <input v-model="newContactListName" placeholder="Nome da Lista" />
        <button type="submit">Criar Lista</button>
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
    name: 'Agendas',
    setup() {
      const apiService = new ApiService();
      const contactLists = ref([]);
      const newContactListName = ref('');
  
      const fetchContactLists = async () => {
        const response = await apiService.getAllContactList();
        contactLists.value = response.data;
      };
  
      const createContactList = async () => {
        if (newContactListName.value) {
          const response = await apiService.createContactList({ name: newContactListName.value });
          contactLists.value.push(response.data);
          newContactListName.value = '';
        }
      };
  
      onMounted(fetchContactLists);
  
      return {
        contactLists,
        newContactListName,
        createContactList,
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
  
  .grid-container {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
    gap: 0.5rem;
    padding: 0;
  }
  
  .grid-item {
    padding: 0.5rem;
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
  