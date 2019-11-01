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
      <v-alert v-if="message" :type="message.type" dismissible>
            {{message.value}}
          </v-alert>
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
        }
      },

      computed: {
        ...mapGetters({
          message: 'getMessage'
        })
      }
    }
</script>

<style>
</style>