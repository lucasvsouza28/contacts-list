    <template>
        <v-layout>
                <v-row v-if="loadingContacts" justify="center">
                    <v-progress-circular indeterminate />
                </v-row>
                <v-row>          
                    <v-col v-if="contacts && contacts.length" cols="6" :md="(selectedContact) ? 6 : 12">
                        <v-row justify="space-around" align="start">
                            <v-card
                                class="ma-2 pa-4"
                                v-for="(contact) in contacts" :key="contact.id"
                                tile
                                @click="selectContactId(contact.id)">
                                <v-card-title class="align-end fill-height" style="position: relative">
                                    <v-icon
                                        color="red"
                                        class="delete-icon"
                                        @click.stop="deleteContact(contact.id)">
                                        delete
                                    </v-icon>
                                    {{ contact.name }}
                                </v-card-title>
                            </v-card>
                        </v-row>            
                    </v-col>
                    <v-col col="12" v-else style="text-align: center">
                        <v-icon>sentiment_dissatisfied</v-icon> Parece que você não tem nenhum contato
                    </v-col>
                
                    <v-col v-if="selectedContact" cols="6" md="6">
                        <ContactDetail :contact="selectedContact" />
                    </v-col>
            </v-row>   
        </v-layout>
    </template>

    <script>
    import ContactDetail from './contact-detail';
    import { mapActions, mapGetters } from 'vuex';

    export default {
        props: ['contacts'],

        components: {
            ContactDetail
        },

        methods: {
            ...mapActions(['selectContactId', 'deleteContact'])
        },

        computed: {
        ...mapGetters({
            selectedContact: 'getSelected',
            loadingContacts: 'getLoadingContacts'
          }),
      }

    }
    </script>

    <style>

    </style>