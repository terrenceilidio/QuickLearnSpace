<template>
    <Page>
        <ActionBar class="bg-purple text-white">
            <GridLayout verticalAlignent="center" width="100%" columns="auto, *">
                <Label verticalAlignment="center" :text="'mdi-menu' | fonticon" class="mdi" :fontSize="30" @tap="$refs.drawer.nativeView.showDrawer()" col="0"/>
                <Label verticalAlignment="center" :fontSize="18" class="title" text="Welcome to QuickLearn.Space"  col="1"/>
            </GridLayout>
        </ActionBar>

        <RadSideDrawer ref="drawer">
            <StackLayout ~drawerContent class="bg-white">
                <Label class="drawer-header bg-purple" text="Drawer"/>

                <Label class="drawer-item" text="Item 1"/>
                <Label class="drawer-item" text="Item 2"/>
                <Label class="drawer-item" text="Item 3"/>
            </StackLayout>

            <GridLayout ~mainContent columns="*" rows="*">
                <Navigator defaultRoute="/login"/>
            </GridLayout>
        </RadSideDrawer>
    </Page>
</template>

<script lang="ts">
  export default {
    data() {
      return {
        msg: 'Hello World!'
      }
    }
  }
</script>

<style scoped>
    .title {
        text-align: left;
        padding-left: 16;
    }

    .message {
        vertical-align: center;
        text-align: center;
        font-size: 20;
        color: #333333;
    }

    .drawer-header {
        padding: 50 16 16 16;
        margin-bottom: 16;
        color: #ffffff;
        font-size: 24;
    }

    .drawer-item {
        padding: 8 16;
        color: #333333;
        font-size: 16;
    }
</style>
