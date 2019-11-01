import * as mutationTypes from './mutation-types';
import Vue from 'vue';

export default {
    [mutationTypes.LOAD_CONTACTS] (state) {
      state.loadingContacts = true;
    },
    [mutationTypes.LOAD_CONTACTS_SUCCESS] (state, payload) {
      state.loadingContacts = false;
      state.contacts = payload;
    },
    [mutationTypes.LOAD_CONTACTS_ERROR] (state, payload) {
      state.loadingContacts = false;
      state.message = {type: 'error', value: payload };
    },
    [mutationTypes.SELECT_CONTACT_ID] (state, payload) {
      state.selectedId = payload;
    },
    [mutationTypes.LOAD_INFOS] (state) {
      state.loadingInfos = true;
    },
    [mutationTypes.LOAD_INFOS_ERROR] (state, payload) {
      state.loadingInfos = false;
      state.message = {type: 'error', value: payload };
    },
    [mutationTypes.LOAD_INFOS_SUCCESS] (state, payload) {
      state.loadingInfos = false;
      
      const idx = state.contacts.findIndex(c => c.id === payload.contactId);
      state.contacts.splice(idx, 1, {...state.contacts[idx], infos: Vue.set(state.contacts[idx], 'infos', payload.data)})
    },
    [mutationTypes.SAVE_CONTACT_SUCCESS] (state, payload) {
      const idx = state.contacts.findIndex(c => c.id === payload.id);
  
      if (idx >= 0) 
        state.contacts.splice(idx, 1, {...state.contacts[idx] })
      else
        state.contacts = [...state.contacts, payload]
      
      state.message = {type: 'success', value: 'Contato salvo com sucesso' };
    },
    [mutationTypes.DELETE_CONTACT_ERROR] (state, payload) {
      state.message = {type: 'error', value: payload };
    },
    [mutationTypes.DELETE_CONTACT_SUCCESS] (state, payload) {
      state.contacts = [...state.contacts.filter((c) => c.id !== payload )]
      state.message = {type: 'success', value: 'Contato deletado com sucesso' };
    },
    [mutationTypes.SET_FILTER] (state, payload) {
      setTimeout(()=> {
        state.filter = payload;
      }, 1000);
    }
  }