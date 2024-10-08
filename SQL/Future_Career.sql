PGDMP     0    2                {           Future_Career_DB    13.2    13.2 $    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    164330    Future_Career_DB    DATABASE     v   CREATE DATABASE "Future_Career_DB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_United States.1252';
 "   DROP DATABASE "Future_Career_DB";
                postgres    false            �            1259    172471    lesson_grades    TABLE     �   CREATE TABLE public.lesson_grades (
    lesson_grades_id integer NOT NULL,
    user_id integer,
    da double precision,
    ca double precision,
    py double precision,
    ui double precision,
    ds double precision
);
 !   DROP TABLE public.lesson_grades;
       public         heap    postgres    false            �            1259    172469 "   lesson_grades_lesson_grades_id_seq    SEQUENCE     �   CREATE SEQUENCE public.lesson_grades_lesson_grades_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public.lesson_grades_lesson_grades_id_seq;
       public          postgres    false    205            �           0    0 "   lesson_grades_lesson_grades_id_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public.lesson_grades_lesson_grades_id_seq OWNED BY public.lesson_grades.lesson_grades_id;
          public          postgres    false    204            �            1259    172458    test_grades    TABLE     �   CREATE TABLE public.test_grades (
    test_grades_id integer NOT NULL,
    user_id integer,
    da double precision,
    ca double precision,
    py double precision,
    ui double precision,
    ds double precision
);
    DROP TABLE public.test_grades;
       public         heap    postgres    false            �            1259    172456    test_grades_test_grades_id_seq    SEQUENCE     �   CREATE SEQUENCE public.test_grades_test_grades_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public.test_grades_test_grades_id_seq;
       public          postgres    false    203            �           0    0    test_grades_test_grades_id_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public.test_grades_test_grades_id_seq OWNED BY public.test_grades.test_grades_id;
          public          postgres    false    202            �            1259    172484    times_clicked    TABLE     �   CREATE TABLE public.times_clicked (
    times_clicked_id integer NOT NULL,
    da integer,
    ca integer,
    user_id integer,
    py integer,
    ui integer,
    ds integer
);
 !   DROP TABLE public.times_clicked;
       public         heap    postgres    false            �            1259    172482 "   times_clicked_times_clicked_id_seq    SEQUENCE     �   CREATE SEQUENCE public.times_clicked_times_clicked_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public.times_clicked_times_clicked_id_seq;
       public          postgres    false    207            �           0    0 "   times_clicked_times_clicked_id_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public.times_clicked_times_clicked_id_seq OWNED BY public.times_clicked.times_clicked_id;
          public          postgres    false    206            �            1259    172447 
   user_table    TABLE     �   CREATE TABLE public.user_table (
    user_id integer NOT NULL,
    username text NOT NULL,
    password text NOT NULL,
    email text NOT NULL,
    secretanswer text,
    firstname text,
    lastname text
);
    DROP TABLE public.user_table;
       public         heap    postgres    false            �            1259    172445    user_table_user_id_seq    SEQUENCE     �   CREATE SEQUENCE public.user_table_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.user_table_user_id_seq;
       public          postgres    false    201            �           0    0    user_table_user_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.user_table_user_id_seq OWNED BY public.user_table.user_id;
          public          postgres    false    200            7           2604    172474    lesson_grades lesson_grades_id    DEFAULT     �   ALTER TABLE ONLY public.lesson_grades ALTER COLUMN lesson_grades_id SET DEFAULT nextval('public.lesson_grades_lesson_grades_id_seq'::regclass);
 M   ALTER TABLE public.lesson_grades ALTER COLUMN lesson_grades_id DROP DEFAULT;
       public          postgres    false    204    205    205            6           2604    172461    test_grades test_grades_id    DEFAULT     �   ALTER TABLE ONLY public.test_grades ALTER COLUMN test_grades_id SET DEFAULT nextval('public.test_grades_test_grades_id_seq'::regclass);
 I   ALTER TABLE public.test_grades ALTER COLUMN test_grades_id DROP DEFAULT;
       public          postgres    false    203    202    203            8           2604    172487    times_clicked times_clicked_id    DEFAULT     �   ALTER TABLE ONLY public.times_clicked ALTER COLUMN times_clicked_id SET DEFAULT nextval('public.times_clicked_times_clicked_id_seq'::regclass);
 M   ALTER TABLE public.times_clicked ALTER COLUMN times_clicked_id DROP DEFAULT;
       public          postgres    false    206    207    207            5           2604    172450    user_table user_id    DEFAULT     x   ALTER TABLE ONLY public.user_table ALTER COLUMN user_id SET DEFAULT nextval('public.user_table_user_id_seq'::regclass);
 A   ALTER TABLE public.user_table ALTER COLUMN user_id DROP DEFAULT;
       public          postgres    false    200    201    201            �          0    172471    lesson_grades 
   TABLE DATA           V   COPY public.lesson_grades (lesson_grades_id, user_id, da, ca, py, ui, ds) FROM stdin;
    public          postgres    false    205   +       �          0    172458    test_grades 
   TABLE DATA           R   COPY public.test_grades (test_grades_id, user_id, da, ca, py, ui, ds) FROM stdin;
    public          postgres    false    203   J+       �          0    172484    times_clicked 
   TABLE DATA           V   COPY public.times_clicked (times_clicked_id, da, ca, user_id, py, ui, ds) FROM stdin;
    public          postgres    false    207   t+       �          0    172447 
   user_table 
   TABLE DATA           k   COPY public.user_table (user_id, username, password, email, secretanswer, firstname, lastname) FROM stdin;
    public          postgres    false    201   �+       �           0    0 "   lesson_grades_lesson_grades_id_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public.lesson_grades_lesson_grades_id_seq', 3, true);
          public          postgres    false    204            �           0    0    test_grades_test_grades_id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('public.test_grades_test_grades_id_seq', 3, true);
          public          postgres    false    202            �           0    0 "   times_clicked_times_clicked_id_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('public.times_clicked_times_clicked_id_seq', 1, false);
          public          postgres    false    206            �           0    0    user_table_user_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.user_table_user_id_seq', 12, true);
          public          postgres    false    200            @           2606    172476     lesson_grades lesson_grades_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public.lesson_grades
    ADD CONSTRAINT lesson_grades_pkey PRIMARY KEY (lesson_grades_id);
 J   ALTER TABLE ONLY public.lesson_grades DROP CONSTRAINT lesson_grades_pkey;
       public            postgres    false    205            >           2606    172463    test_grades test_grades_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.test_grades
    ADD CONSTRAINT test_grades_pkey PRIMARY KEY (test_grades_id);
 F   ALTER TABLE ONLY public.test_grades DROP CONSTRAINT test_grades_pkey;
       public            postgres    false    203            B           2606    172489     times_clicked times_clicked_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public.times_clicked
    ADD CONSTRAINT times_clicked_pkey PRIMARY KEY (times_clicked_id);
 J   ALTER TABLE ONLY public.times_clicked DROP CONSTRAINT times_clicked_pkey;
       public            postgres    false    207            :           2606    172455    user_table user_table_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public.user_table
    ADD CONSTRAINT user_table_pkey PRIMARY KEY (user_id);
 D   ALTER TABLE ONLY public.user_table DROP CONSTRAINT user_table_pkey;
       public            postgres    false    201            <           2606    172496    user_table username 
   CONSTRAINT     R   ALTER TABLE ONLY public.user_table
    ADD CONSTRAINT username UNIQUE (username);
 =   ALTER TABLE ONLY public.user_table DROP CONSTRAINT username;
       public            postgres    false    201            C           2606    172464    test_grades fk_1    FK CONSTRAINT     y   ALTER TABLE ONLY public.test_grades
    ADD CONSTRAINT fk_1 FOREIGN KEY (user_id) REFERENCES public.user_table(user_id);
 :   ALTER TABLE ONLY public.test_grades DROP CONSTRAINT fk_1;
       public          postgres    false    201    2874    203            D           2606    172477    lesson_grades fk_2    FK CONSTRAINT     {   ALTER TABLE ONLY public.lesson_grades
    ADD CONSTRAINT fk_2 FOREIGN KEY (user_id) REFERENCES public.user_table(user_id);
 <   ALTER TABLE ONLY public.lesson_grades DROP CONSTRAINT fk_2;
       public          postgres    false    201    2874    205            E           2606    172490    times_clicked fk_3    FK CONSTRAINT     {   ALTER TABLE ONLY public.times_clicked
    ADD CONSTRAINT fk_3 FOREIGN KEY (user_id) REFERENCES public.user_table(user_id);
 <   ALTER TABLE ONLY public.times_clicked DROP CONSTRAINT fk_3;
       public          postgres    false    2874    207    201            �   +   x�3�4�44@F\F��@1N�2�44�A��)�)W� Ǵ�      �      x�3�4�44!aj����� &n      �      x������ � �      �   
  x�u�Mo�0����A��mS�u�*���֋5(�$���/q��մC�7ȏ?b\����-&��.O�Hv(��ϋ�&�}��@�w�(7��2VR �u�4������E��ؙ�	� O���l«�qȩcx�Y�bM�J�ʖ��}���A�K���4��dKIMF[�pp#��l~�xp+Ѭ�l˴܆J;�gjw�,��������*i(0�1}�o]�٤X��gZ��ujT=y�Ĭ�Z>�.�h�܇��F�Z��up����!�c     