import axios from 'axios'

const API_BASE = 'http://localhost:5000/api/v1' // substitua pela URL da sua API se for diferente

export async function getContactList() {
  try {
    const response = await axios.get(`${API_BASE}/getContactListById`)
    return response.data
  } catch (error) {
    console.error('Erro ao buscar agendas:', error)
    return []
  }
}
