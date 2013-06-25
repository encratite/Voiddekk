set client_min_messages to warning;

drop table if exists player cascade;

-- Players registered with the system
create table player(
	id serial primary key,
	name text not null,
	-- SHA-3 (512-bit) hash of salt and password
	password_hash bytea not null
);

-- Index for looking up players based on their names when logging in
create index player_name_index on player(name);

drop table if exists player_card cascade;

-- Cards owned by players
-- One card may be in multiple decks, that's why deck membership is dealt with in an additional relation
create table player_card(
	-- They require an ID of their own for the purpose of trading and association with decks
	id serial primary key,
	-- The numeric ID of the card from the card configuration file
	card_id integer not null,
	-- The ID of the owner
	player_id integer references player(id) not null
);

-- Index for looking up the cards owned by a player
create index player_card_index_player_id on player_card(player_id);

drop table if exists player_deck cascade;

-- Decks created by players
create table player_deck(
	id serial primary key,
	name text not null,
	-- The ID of the owner of the deck
	player_id integer references player(id) not null
);

-- Index for looking up the decks owned by a player
create index player_deck_index_player_id on player_deck(player_id);

drop table if exists deck_card cascade;

-- Cards belonging to a deck
create table deck_card(
	-- The ID of the deck the card is in
	deck_id integer references player_deck(id) not null,
	-- The ID of the card
	card_id integer references player_card(id) not null,
	-- A flag that indicates if it's part of the initial hand
	is_initial boolean not null
);

-- Index for looking up the cards belonging to a deck
create index deck_card_index_deck_id_card_id on deck_card(deck_id, card_id);