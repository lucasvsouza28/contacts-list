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
    getSelectedId(state) {
      return state.selectedId;      
    },
    getSelected (state, getters) {
      return getters.getSelectedId < 1
        ? Object.assign({}, { infos: [{}] }) 
        : getters.getContacts.find(c=> c.id === getters.getSelectedId);
    },
  
    getFilteredContacts(state) {
      const rgx = new RegExp(state.filter, 'ig')
      return state.contacts.filter(c => !state.filter || rgx.test(c.name) );
    }
  
  }