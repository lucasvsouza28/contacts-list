import * as mutationTypes from './mutation-types';
import axios from 'axios';

export default ({
    async loadContacts ({ commit }) {
      try {
        commit(mutationTypes.LOAD_CONTACTS)
  
        const resp = await axios('/api/contacts');
        commit(mutationTypes.LOAD_CONTACTS_SUCCESS, resp.data);
        
      } catch (error) {
        commit(mutationTypes.LOAD_CONTACTS_SUCCESS, error.message);
      }   
  
    },
    setContacts ({ commit }, payload) {
      commit(mutationTypes.LOAD_CONTACTS_SUCCESS, payload)
    },
    async selectContactId ({commit}, payload) {
      
      if (payload > -1) {      
  
        try {
          commit(mutationTypes.LOAD_INFOS)
  
          const resp = await axios(`/api/contacts/${payload}/info`);
  
          commit(mutationTypes.LOAD_INFOS_SUCCESS, {contactId: payload, data: resp.data})
        } catch (error) {
          commit(mutationTypes.LOAD_INFOS_ERROR, error.message)
        }
      }
  
      commit(mutationTypes.SELECT_CONTACT_ID, payload)
    },
    async saveContact ({commit}, payload) {
      try {
  
        let newData = null;
  
        if (payload.id > -1) {        
          const resp = await axios.put(`/api/contacts/${payload.id}`, payload);
          newData = payload;
        }
        else {
          const resp = await axios.post('/api/contacts', payload);
          newData = resp.data
        }
        
        commit(mutationTypes.SAVE_CONTACT_SUCCESS, newData);
      } catch (error) {
        commit(mutationTypes.SAVE_CONTACT_ERROR, error.message);
      }
    },
    async deleteContact({commit}, payload) {
      try {
  
        const resp = await axios.delete(`/api/contacts/${payload}`);
  
        commit(mutationTypes.DELETE_CONTACT_SUCCESS, payload);
      } catch (error) {
        commit(mutationTypes.DELETE_CONTACT_ERROR, error.message);
      }
    },
    filterContacts ({commit}, payload) {
      commit(mutationTypes.SET_FILTER, payload);
    }
  })