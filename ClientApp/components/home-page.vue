      <template>
      <div style="width: 100%">
          <v-row row>
            <v-col cols="12" md="12">
              <v-tooltip right>
                <template v-slot:activator="{ on }">
                  <v-btn @click="selectContactId(-1)" color="primary" large v-on="on">
                    <v-icon>person_add</v-icon> Adicionar Contato
                  </v-btn>
                </template>
                <span>Novo contato</span>
              </v-tooltip>
              <v-text-field @keyup="filterContacts(filter)" v-model="filter" label="Pesquisar contatos"></v-text-field>
            </v-col>
          </v-row>

        <ContactsList :contacts="contacts" />
      </div>
      </template>

      <script>
      import Vue from 'vue';
      import ContactsList from './contact-list.vue'
      import { mapActions, mapGetters } from 'vuex';

      export default {
        components: {
          ContactsList
        },

        mounted(){
          this.loadContacts();
        },

        data () {
          return {
            filter: ''
          }
        },

        methods: {
              ...mapActions(['loadContacts', 'selectContactId', 'filterContacts'])
          },

        computed: {
          ...mapGetters({
              contacts: 'getFilteredContacts',
            }),        
        }

      }
      </script>

      <style>

        .delete-icon{
          position: absolute;
          top: -10px;
          right: -10px;
        }

      </style>
