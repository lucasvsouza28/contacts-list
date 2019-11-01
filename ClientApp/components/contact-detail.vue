    <template>
        <v-container fluid>
            <v-row style="min-width: 100%" justify="center">
                <v-subheader class="headline">
                    {{contact.id ? `#${contact.id} - ${contact.name}` : 'Novo contato'}}
                </v-subheader>

            </v-row>

            <v-row v-if="loadingInfos" justify="center">
                <v-progress-circular indeterminate  />
            </v-row>
            <v-row v-else>
                <v-col>            
                    <v-form v-if="contact" v-model="valid">
                        <v-text-field v-model="contact.name" label="Nome" />
                        
                        <v-row justify="center">
                            <v-subheader>Informações adicionais</v-subheader>                            
                        </v-row>

                        <v-row v-if="contact.infos && contact.infos.length">
                            <v-col cols="12" md="12" v-for="(info) in contact.infos" :key="info.id">
                                <v-row>
                                    <v-col cols="12" md="6">
                                        <v-select :items="types" v-model="info.type"></v-select>
                                    </v-col>
                                    <v-col cols="12" md="6">
                                        <v-text-field v-model="info.value"></v-text-field>
                                    </v-col>
                                </v-row>                            
                            </v-col>                        
                        </v-row>

                        <v-row>

                        </v-row>

                        <v-layout align-end justify-end>

                            <v-tooltip top>
                                <template v-slot:activator="{ on }">
                                    <v-btn
                                        large class="mr-4"
                                        v-on="on"
                                        v-if="contact.id"
                                        @click="newInfo">
                                        <v-icon>note_add</v-icon> Nova Informação
                                    </v-btn>
                                </template>
                                <span>Nova informação de contato</span>
                            </v-tooltip>

                            <v-tooltip top>
                                <template v-slot:activator="{ on }">
                                    <v-btn
                                        large
                                        color="success"
                                        v-on="on"
                                        @click="saveContact(contact)">
                                        <v-icon>save</v-icon> Salvar Contato
                                    </v-btn>
                                </template>
                                <span>Salvar contato</span>
                            </v-tooltip>
                        </v-layout>                        

                    </v-form>
                </v-col>
            </v-row>
        </v-container>
    </template>

    <script>
    import Vue from 'vue';
    import { mapActions, mapGetters } from 'vuex';

    export default {
        props: ['contact'],

        data() {
            return {
                valid: false,
                types: [
                    { text: 'Telefone', value: 0 },
                    { text: 'Email', value: 1 }
                ]
            }        
        },

        methods: {
            newInfo(){

                this.contact.infos = [...(this.contact.infos || []), { contactId: this.contact.id }]

            },
            ...mapActions(['saveContact'])
        },

        computed: {
            ...mapGetters({
                loadingInfos:'getLoadingInfos'
            })
        }

    }
    </script>

    <style>

    </style>