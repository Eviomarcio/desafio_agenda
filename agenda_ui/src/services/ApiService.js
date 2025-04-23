class ApiService {
    constructor(baseURL = 'http://localhost:5202/api/v1') {
        this.baseURL = baseURL;
    }

    async createContactList(data) {
        const response = await fetch(`${this.baseURL}/createContactList`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data),
        });
        return response.json();
    }

    async getContactListById(id) {
        const response = await fetch(`${this.baseURL}/getContactListById?id=${id}`);
        return response.json();
    }

    async getAllContactList() {
        const response = await fetch(`${this.baseURL}/contactList`);
        console.log(response);
        return response.json();
    }

    async getAllContacts(idContactList) {
        return this.api.get(`/getAllContact`, {
          params: { idContactList },
        });
      }

    async createContact(data) {
        const response = await fetch(`${this.baseURL}/createContact`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data),
        });
        return response.json();
    }

    async getContactPhone(phone) {
        const response = await fetch(`${this.baseURL}/getContactPhone?phone=${phone}`);
        return response.json();
    }

    async getContactById(id) {
        const response = await fetch(`${this.baseURL}/getContactById?id=${id}`);
        return response.json();
    }

    async getAllContacts(idContactList) {
        const response = await fetch(`${this.baseURL}/getAllContact?idContactList=${idContactList}`);
        return response.json();
    }

    async updateContact(data) {
        const response = await fetch(`${this.baseURL}/updateContact`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data),
        });
        return response.json();
    }

    async deleteContact(idContact) {
        const response = await fetch(`${this.baseURL}/deleteContact?idContact=${idContact}`, {
            method: 'DELETE',
        });
        return response.json();
    }
}

export default ApiService;