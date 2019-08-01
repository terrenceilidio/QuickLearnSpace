<template>
    <Page actionBarHidden="true">
        <GridLayout columns="*,auto" rows="*,auto,auto,auto">
          <Gif height="100%" width="auto" class="p-x-5" verticalAlignment="center" row="0" src="https://i.gifer.com/DdaO.gif"></Gif>
          <StackLayout row="1">
            <MDRipple class="m-y-5 m-x-10" @tap="login(socialNetwork.name)" v-for="(socialNetwork,i) in socialNetworks" :key="i">
                <CardView :backgroundColor="socialNetwork.backgroundColor" class="text-white" rippleColor="blue">
                    <GridLayout class="p-10" columns="auto,*">
                        <Label col="0" class="mdi p-5 p-x-10" fontSize="22%" verticalAlignment="center" :text="socialNetwork.icon | fonticon"></Label>
                        <Label class="p-5" col="0" colSpan="2" fontSize="13%" textAlignment="center" verticalAlignment="center" :text="`Continue with ${socialNetwork.name}`"></Label>
                    </GridLayout>
                </CardView>
            </MDRipple>
            <MDRipple @tap="readTermsOfUse()" class="m-x-10">
              <Label class="m-t-10" fontSize="10%" textAlignment="center" verticalAlignment="center" text="By signing in"></Label>
              <Label class="m-b-10" fontSize="10%" :textWrap="true" textAlignment="center" verticalAlignment="center">
                <FormattedString>
                  <Span text="you agree to our " />
                  <Span text="terms of use " class="text-purple" fontStyle="italic" />
                  <Span text="and " />
                  <Span text="privacy policy " class="text-purple" fontStyle="italic" />
                </FormattedString>
              </Label>
            </MDRipple>
          </StackLayout>
        </GridLayout>
    </Page>
</template>

<script lang="ts">
  export default {
    data() {
      return {
        socialNetworks:[{
          name:'Google',
          backgroundColor:'#db3236',
          icon:'mdi-google'

        },{
          name:'Facebook',
          backgroundColor:'#3b5998',
          icon:'mdi-facebook'

        },{
          name:'Twitter',
          backgroundColor:'#00acee',
          icon:'mdi-twitter'

        },{
          name:'Phone',
          backgroundColor:'#000000',
          icon:'mdi-phone'

        }]
      }
    },
    methods:{
      login(name){
        alert(`Handle log in via ${name}`);
      },
      readTermsOfUse(){
        alert("Read the terms of use and privacy policy");
      }
    }
  }
</script>

<style scoped>

</style>
