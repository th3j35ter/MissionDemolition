# 🏹 Mission Demolition - Enhancements

## 🔹 Enhancement: Lowest Shots Tracking 🏆
**Added a feature that tracks and saves the player's lowest number of shots fired across multiple game sessions.**  

---

## 📌 How It Works:
- The game now **remembers the fewest shots taken** to complete all levels.  
- If the player beats their **best shots record**, it updates and saves automatically.  
- The **best shots record** is displayed on the UI as **"Best Shots: X"**.  
- This encourages **players to improve** and complete levels with fewer shots!  

---

## 🎯 Why It’s Cool?
✅ **Long-Term Challenge** – Players can **compete against themselves** to optimize their shots.  
✅ **Skill Improvement** – Encourages replayability by trying to **beat their own record**.  
✅ **Persistent Data** – The **best shots score is saved** even after closing and reopening the game.  

---

## 🛠️ Implementation Details
- The **best shots count is stored using `PlayerPrefs`**, allowing it to persist between game runs.  
- **If a new record is achieved**, it **overwrites the previous best score**.  
- UI was updated to display the **best shots record** in real-time.  

---

## 🚀 How to Play with the New Feature
1. **Launch the game and complete all levels.**  
2. **Check your "Best Shots" score in the UI.**  
3. **Try again and aim for a lower number of shots!**  
4. If you beat your record, the game **automatically saves your new best score!** 🎯  

Enjoy optimizing your shots and setting new records! 🏆🔥  
