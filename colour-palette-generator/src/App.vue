<template>
  
  <h1>{{ title }}</h1>
  <hr/>
  <h3>{{ msg }}</h3>
  <hr/>
  <ColourPanel v-if="colourGenerated" :colours=this.colourObj />
  
  <button v-if="colourGenerated"  :disabled="paletteSaved" :style="{margin:'20px'}" class="primary-button" @click="showSaveBtn">{{paletteSaved ? 'Palette saved' : 'Save pallet?'}}</button>
  <button :style="{margin:'20px'}" class="primary-button" @click="generateColours">Generate</button> 
  <form v-if="showSave" > 
    <label for="saveName">Enter a name: </label>
    <input id="saveName" v-model="enteredName"/>
    <button @click.prevent="savePalette">Save</button>
  </form>
</template>

<script>
import ColourPanel from './components/ColourPanel.vue'

export default {

  data() {
    return { 
      title: 'Random Colour Palette Generator',
      msg: "Click the button below to randomly generate a colour palette",
      colourObj: {
        id:'',
        savedName:'',
        colours:{
          firstColour: '',
          secondColour:'',
          thirdColour:'',
          fourthColour:'',
        }
      },
      enteredName: '',
      colourGenerated: false,
      paletteSaved: false,
      showSave: false
    }
  },
  components: {
    ColourPanel
  },
  methods:{

    generateColours(){
      this.colourGenerated = false
      this.paletteSaved = false
      this.colourObj.id = Math.ceil(Math.random() * (9999 - 1000) + 1000)
      Object.entries(this.colourObj.colours).forEach(([key]) =>{
        this.colourObj.colours[key] = '#' + (Math.random() * 0xFFFFFF << 0).toString(16).padStart(6, '0')
      })
      console.log(this.colourObj)
      this.colourGenerated = true
      return this.colours
    },

    showSaveBtn(){
      this.showSave = true
    },

    savePalette(){
      this.colourObj.savedName = this.enteredName
      this.paletteSaved = true
      this.showSave = false
      console.log(this.colourObj)
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

hr {
  border: none;
  height: 1px;
  background: linear-gradient(to right, rgba(0, 0, 0, 0), #bbb, rgba(0, 0, 0, 0));
  margin: 30px 0;
}

.primary-button{
  background-color: black;
  color: white;
  font-size: 25px;
  border-radius: 0.6rem;
  
}
.primary-button:hover{
  background-color: #2c3e50;

}

.primary-button:active{
  box-shadow:#2c3e50 2px 1px
}

.primary-button:disabled{
  background-color: rgb(56, 124, 56);
}
</style>
