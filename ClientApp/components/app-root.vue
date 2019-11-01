<template>
  <v-app id="contacts">
    <v-app-bar
      app
      clipped-left
      color="primary"
    >
      <span class="title ml-3 mr-5 white--text"><span class="font-weight-light">Contatos</span></span>
      <div class="flex-grow-1"></div>
    </v-app-bar>

    <v-content>
      <v-container
        class="grey lighten-4"
      >
      <v-snackbar v-model="message" :type="message.type" timeout="2000" bottom>
            {{message.value}}
          </v-snackbar>
        <v-layout justify>          
            <router-view></router-view>
        </v-layout>
      </v-container>
    </v-content>    

  </v-app>
</template>

<script>
  import { mapGetters } from 'vuex';

    export default {
      components: {
      },

      data () {
        return {
          newMessage: ''
        }
      },

      computed: {
        ...mapGetters({
          message: 'getMessage'
        })
      },
      watch: {
        message (newV, oldV){
          this.newMessage = null;
          this.newMessage = newV;
        }
      }
    }
</script>

<style>
</style>