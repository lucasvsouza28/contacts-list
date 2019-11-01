export default {

    getMessage(state) {
      return state.message
    },
  
    getLoadingContacts(state) {
      return state.loadingContacts
    },
  
    getLoadingInfos(state) {
      return state.loadingInfos
    },
  
    getContacts(state) {
      return state.contacts;
    },
    getSelected (state) {
      return state.selectedId === -1
        ? Object.assign({}, { infos: [{}] }) 
        : state.contacts.find(c=> c.id === state.selectedId);
    },
  
    getFilteredContacts(state) {
      const rgx = new RegExp(state.filter, 'ig')
      return state.contacts.filter(c => !state.filter || rgx.test(c.name) );
    }
  
  }