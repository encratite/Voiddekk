-- This is a PostgreSQL script

set client_min_messages to warning;

drop table if exists player cascade;

-- Players registered with the system
create table player(
	id serial primary key,
	name text unique not null,
	-- Currency owned by the player, name intentionally generic
	currency integer not null,
	-- Time this account was registered
	time_registered timestamp not null,
	-- Time of last login, useful for removing old accounts
	last_login timestamp not null
);

-- Index for looking up players by name in future search features
create index player_name_index on player(name);

drop table if exists persona cascade;

-- Mozilla Personas that have been used in the system
-- Also used to associate sessions with personas and players
create table persona(
	id serial primary key,
	-- Persona fields
	email text unique not null,
	issuer text not null,
	-- This field needs to get updated for every Persona-based authentication
	expires timestamp not null,
	-- The session key generated during authentication may be used in future to log in without the persona
	session_key text unique not null,
	-- Once a player has been associated with the Persona this ID is specified, until then this field is null
	player_id integer references player(id)
);

-- Index for looking up personas by email during Persona-based authentication
create index persona_email_index on persona(email);
-- Index for checking if a session key is valid
create index persona_session_key on persona(session_key);
-- Index for looking up a player associated with a persona
create index persona_player_id on persona(player_id);

drop table if exists player_card cascade;

-- Cards owned by players
-- One card may be in multiple decks, that's why deck membership is dealt with in an additional relation
create table player_card(
	-- They require an ID of their own for the purpose of trading and association with decks
	id serial primary key,
	-- The numeric ID of the card from the card configuration file
	type integer not null,
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
	-- References the ID from the faction configuration file
	faction integer not null,
	-- The ID of the owner of the deck
	player_id integer references player(id) not null,
	-- Deck names should be unique per player
	unique(name, player_id)
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