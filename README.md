# Awave-Introductory-Task(Failed :()

## Task Description
<details><summary>Description</summary>
  
### Task
### Create website “My favorite games”. The purpose of the website is to vote for games and see their statistics. Website should contain 3 pages:

 >1) Results: page with two parts:
  dashboard/widget that shows some various metrics. Some ideas – top 5 most rated games, top 5 highest rated games, lowest rated game, average game rating. Feel free to express     yourself here but don’t overdo it.
  Below dashboard, a table showing top 20 recent ratings (Columns: Game Title, Name, Email, comment and rating)

 >2) Game list: page that displays list of all games in table. Have sample data of at least 20 games. Should contain columns like: Title, Year, Average Rating. Should be             searchable, paginable and sortable.

 >3) Rate game: selecting game from the list should navigate to Rate game page. This page should show the game information you are rating and have following fields: Name, Email,     Comment, Rating (from 1-10). Name, Email, Rating fields are required, only one rating per Email is allowed. After submitting, redirect to results page.

Sample data and data handling: Create sample data manually or consider using https://www.igdb.com/top-100/games to scrap games list or https://api.rawg.io/api/games to get json for data feed. The database should be MSSQL LocalDB in AppData folder.

</details>

## Results
<details><summary>Results</summary>
  
  ## DONE
  
  - [x] Added basic Structure(DAL Layer, BL Layer and Web)
  - [x] Added CRUD
  - [x] Added all necessaries repositories
  - [x] Added Unit of Work Pattern
  - [x] Added DbConnection(but only for testing purpose)
  - [x] Added light business logic
  - [x] Added light logic to controllers
  
  Overview: Unhappy with the results
  
  ## TODO
  - [ ] Finilize business logic
  - [ ] Add Database into project(local for now)
  - [ ] Set initial data for db
  - [ ] Add web scrapper to get games
  - [ ] Add migrations
  - [ ] Finilize controllers
  - [ ] Update routings
  - [ ] Add db constraints(i.e. allow person to vote only once for each game)
  - [ ] Add tests
  - [ ] Add front end part(razor pages, js(jquery) etc...)
  - [ ] Add documenation(code description)
</details>

## Feelings

### Quite an interesting project and I will finish it just for myself. I wouldn't say it is extra difficult...probably just time-consuming and voluminous especially when you do it in parallel with your main work :D. It's not an excuse why I wasn't able to finish it in time and it's only my bad. I think I've spent a lot of time thinking how this project would look like in the end because I wanted to make it impressive.

### Many thanks for the opportunity!

### Would like to ask you to leave a review about my code styling, file structure and some advice from your perspective. I would appreciate it!

### Will be in touch!
  
