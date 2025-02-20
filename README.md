# HeartcoreContentMigration

### Description of task


1. Create a Heartcore project
2. Create Two languages English(US) & Danish(Denmark)
3. Create the following structure in the project
- Create two folders **Elements** & **pages**
- In the **Elements folder** create an **Element type** called **Genre**. Create two properties called **Index number & Title**. **Index number(Textstring, Mandatory)**, **Title(Textstring, Vary by culture)**.
- In the **Pages** folder create three Document Types called: **LoginPage**, **TV Show** & **TV Shows**.
- **LoginPage:** is empty (We might not need it)
- **Tv Show:** needs 3 properties: **Genres(Blocklist using Element type: Genre)**, **Show Summary(RTE, Vary by culture)**, **Show Image(Image Media Picker)**.
- **TV Shows:** is empty
- The structure ↓
- ![image](https://github.com/user-attachments/assets/b4d17bd8-ba88-40ea-8732-592355448cb4)
4. Create a content node populated automatically using the [Heartcore Client Library](https://github.com/umbraco/Umbraco.Headless.Client.Net) and the [api.tvmaze.com](https://www.tvmaze.com/api)
5.  If a show exists with an ID do the following ↓
- Update Existing Property:
   - If the property already exists in Heartcore but is empty, check if TVMAZE has a value for it. If it does, update the property in Heartcore with the value from TVMAZE.
- Create New Content with Media:
   - If the property doesn't exist in Heartcore, download the images from TVMAZE, save them to the media section in Heartcore, and link them to a new content node you create.
