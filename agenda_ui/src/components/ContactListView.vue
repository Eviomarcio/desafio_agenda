<!-- <template>
    <div class="home-container">
      <h1 class="title">Listas de Contatos</h1>
  
      <div class="list">
        <div v-for="list in contactLists" :key="list.id" class="card">
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
    max-width: 600px;
    margin: auto;
    padding: 2rem;
    display: flex;
    flex-direction: column;
    gap: 1.5rem;
  }
  
  .title {
    font-size: 2rem;
    font-weight: bold;
    text-align: center;
  }
  
  .list {
    display: flex;
    flex-direction: column;
    gap: 0.75rem;
  }
  
  .card {
    background-color: #f9f9f9;
    border-radius: 8px;
    padding: 1rem;
    box-shadow: 0 0 6px rgba(0, 0, 0, 0.1);
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
   -->
<!-- 
   <template>
    <div class="home-container">
      <h1 class="title">Listas de Contatos</h1>
  
      <div class="grid-container">
        <div v-for="list in contactLists" :key="list.id" class="card">
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
    font-weight: bold;
    text-align: center;
  }
  
  .grid-container {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(240px, 1fr));
    gap: 1.5rem;
  }
  
  .card {
    background-color: #f9f9f9;
    border-radius: 8px;
    padding: 1rem;
    text-align: center;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.05);
    transition: transform 0.2s ease;
  }
  
  .card:hover {
    transform: translateY(-4px);
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
  </style> -->
  
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
  